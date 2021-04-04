using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBuilder : MonoBehaviour
{
    public GameObject mazeSquare;
    public List<Vector3> bfsPath;
    public List<Vector3> seekPath;
    public int sizeOfMaze = 3;
    public List<GameObject> walls;

    public class DisJoint
    {
        int numSets;
        int size;//size of
        int[] rank;//array holding rank
        int[] parent;//lets us know parent
        //constructor 
        public DisJoint(int n)
        {
            size = n;
            numSets = n;
            rank = new int[n];
            parent = new int[n];
            for (int i = 0; i < size; i++)
                MakeSet(i);
        }
        //initialize set
        public void MakeSet(int x)
        {
            parent[x] = x;
            rank[x] = 0;
        }
        //return parent and reassings parent if needed
        public int Find(int x)
        {
            if (x != parent[x])
                parent[x] = Find(parent[x]);
            return parent[x];
        }
        //only links two diff indexes dependent upon rank and adjust rank
        public bool Link(int x, int y)
        {
            if (x == y) return false;//do nothing if call to link an index with itself
            numSets--;//as it linked some sets
            if (rank[x] > rank[y])
                parent[y] = x;
            else
                parent[x] = y;
            if (rank[x] == rank[y])//if both ranks are the same increase rank
                rank[y]++;
            return true;
        }
        public int GetNumSets() { return numSets; }
    }
    class Maze
    {
        List<List<int>> board;//array of list 
        DisJoint set;
        int size;//size of nxn sqaure
        int dim;// n aka # of col
                //positions ex table[i][right]  = table[i][0]
        int right;
        int bottom;
        int left;
        int top;
        public Maze(int i)
        {
            //positions in list
            right = 0;
            bottom = 1;
            left = 2;
            top = 3;

            dim = i;//n
            i *= i;//square size given
            size = i;
            set = new DisJoint(size);//Disjoint set to keep track when all sqaures are in same set
            board = new List<List<int>>(size);
            SetBoard();
        }
        public void SetBoard()
        {
            //initialize squares with 4 walls
            for (int i = 0; i < size; i++)
            {
                List<int> box = new List<int>();
                box.Add(1);
                box.Add(2);
                box.Add(4);
                box.Add(8);
                board.Add(box);
            }
            //add entrance top left
            board[0][left] = 0;
            //add exit bottom right
            board[size - 1][right] = 0;
        }
        public bool Unite(int x, int y)
        {
            return set.Link(set.Find(x), set.Find(y));
        }
        public void PrintBoard()
        {
            string line = "";

            for (int i = 0; i < size; i++)
            {
                int sum = 0;//aka type of wall
                sum = board[i][right] + board[i][bottom] + board[i][left] + board[i][top];
                if (sum < 10)
                    sum += 48;//adjust to print equivalent char
                else
                    sum += 55;//adjust to print equivalent char

                line += (char)sum;
                if ((i + 1) % dim == 0)//start a new row
                    line += '\n';

            }
            print(line+ "\n");

        }
        public string GetBoard()
        {
            string temp = "";
            for (int i = 0; i < size; i++)
            {
                int sum = 0;//aka type of wall
                sum = board[i][right] + board[i][bottom] + board[i][left] + board[i][top];
                if (sum < 10)
                    sum += 48;//adjust to print equivalent char
                else
                    sum += 55;//adjust to print equivalent char
                char ch = (char)sum;
                temp += ch;

            }
            return temp;

        }
        public void MakeMaze()
        {
            //if choice = 0, try to unite square to the right
            //if choice = 1, try to unite sqare to the bottom
            //if choice = 2, try to unite square to the left
            //if choice = 3, try and unite square to the top
            int choice = 0;
            while (set.GetNumSets() != 1)
            {
                int pos; //square in the maze
                choice = UnityEngine.Random.Range(1,10000) % 4;
                // repeat choice n times
                for (int i = 0; i < dim; i++)
                {
                    pos = UnityEngine.Random.Range(1, 10000) % size;//choose rand sqaure
                    if (choice == right)
                    {// right union
                        if ((pos + 1) % dim != 0)
                        {
                            if (Unite(pos, pos + 1))
                            {
                                board[pos][right] = 0;
                                board[pos + 1][left] = 0;
                            }
                        }
                    }
                    else if (choice == left)
                    {//left union
                        if (pos % dim != 0)
                        {
                            if (Unite(pos, pos - 1))
                            {
                                board[pos][left] = 0;
                                board[pos - 1][right] = 0;
                            }
                        }
                    }
                    else if (choice == bottom)
                    {
                        if (pos < (size - dim))
                        {//bottom union
                            if (Unite(pos, pos + dim))
                            {
                                board[pos][bottom] = 0;
                                board[pos + dim][top] = 0;
                            }
                        }
                    }
                    else if (choice == top)
                    {
                        if (pos >= dim)
                        {//top union
                            if (Unite(pos, pos - dim))
                            {
                                board[pos][top] = 0;
                                board[pos - dim][bottom] = 0;
                            }
                        }
                    }
                }

            }

        }

    }

    public class Square
    {
        public bool left;
        public bool right;
        public bool top;
        public bool bottom;
        public void SetLeft(bool b) { left = b; }
        public void SetRight(bool b) { right = b; }
        public void SetTop(bool b) { top = b; }
        public void SetBottom(bool b) { bottom = b; }
    };
    public void AddSquare(List<Square> maze, char ch,float x, float y)
    {
        Square add = new Square();
        GameObject temp = Instantiate(mazeSquare, new Vector3(x, y, 0), Quaternion.identity);
        walls.Add(temp);
        Renderer leftWall = temp.transform.GetChild(0).GetComponent<Renderer>();
        Renderer topWall = temp.transform.GetChild(1).GetComponent<Renderer>();
        Renderer rightWall = temp.transform.GetChild(2).GetComponent<Renderer>();
        Renderer bottomWall = temp.transform.GetChild(3).GetComponent<Renderer>();

        if (ch == '0') { add.left = add.right = add.top = add.bottom = false; }
        else if (ch == '1') {
            add.left = add.top = add.bottom = false; add.right = true;
            rightWall.enabled = true;
        }
        else if (ch == '2') {
            add.left = add.right = add.top = false; add.bottom = true;
            bottomWall.enabled = true;
        }
        else if (ch == '3') {
            add.left = add.top = false; add.right = add.bottom = true;
            rightWall.enabled = bottomWall.enabled = true;
        }
        else if (ch == '4') {
            add.right = add.top = add.bottom = false; add.left = true;
            leftWall.enabled = true;
        }
        else if (ch == '5') {
            add.top = add.bottom = false; add.left = add.right = true;
            leftWall.enabled = rightWall.enabled = true;
        }
        else if (ch == '6') {
            add.right = add.top = false; add.left = add.bottom = true;
            leftWall.enabled = bottomWall.enabled = true;
        }
        else if (ch == '7') {
            add.top = false; add.left = add.right = add.bottom = true;
            leftWall.enabled = rightWall.enabled = bottomWall.enabled = true;
        }
        else if (ch == '8') {
            add.left = add.right = add.bottom = false; add.top = true;
            topWall.enabled = true;
        }
        else if (ch == '9') {
            add.left = add.bottom = false; add.top = add.right = true;
            topWall.enabled = rightWall.enabled = true;
        }
        else if (ch == 'A' || ch == 'a')
        {
            add.left = add.right = false; add.top = add.bottom = true;
            topWall.enabled = bottomWall.enabled = true;
        }
        else if (ch == 'B' || ch == 'b')
        {
            add.left = false; add.right = add.top = add.bottom = true;
            rightWall.enabled = topWall.enabled = bottomWall.enabled = true;
        }
        else if (ch == 'C' || ch == 'c')
        {
            add.right = add.bottom = false; add.left = add.top = true;
            leftWall.enabled = topWall.enabled = true;
        }
        else if (ch == 'D' || ch == 'd')
        {
            add.left = add.right = add.top = true; add.bottom = false;
            leftWall.enabled = rightWall.enabled = topWall.enabled = true;
        }
        else if (ch == 'E' || ch == 'e')
        {
            add.right = false; add.left = add.top = add.bottom = true;
            leftWall.enabled = topWall.enabled = bottomWall.enabled = true;
        }
        else if (ch == 'F' || ch == 'f')
        {
            add.left = add.right = add.top = add.bottom = true;
            leftWall.enabled = topWall.enabled = rightWall.enabled = bottomWall.enabled = true;
        }
        //*** Tag LandMarks for tower Placement
        if(leftWall.enabled == true)
        {
            for (int i = 0; i < leftWall.transform.childCount; i++)
                leftWall.transform.GetChild(i).tag = "Land";
        }
        else
        {
            for (int i = 0; i < leftWall.transform.childCount; i++)
                leftWall.transform.GetChild(i).gameObject.layer = 2;
        }

        if ( topWall.enabled == true)
        {
            for (int i = 0; i < topWall.transform.childCount; i++)
                topWall.transform.GetChild(i).tag = "Land";
        }
        else
        {
            for (int i = 0; i < topWall.transform.childCount; i++)
               topWall.transform.GetChild(i).gameObject.layer = 2;
        }
        if (rightWall.enabled == true)
        {
            for (int i = 0; i < rightWall.transform.childCount; i++)
                rightWall.transform.GetChild(i).tag = "Land";
        }
        else
        {
            for (int i = 0; i < rightWall.transform.childCount; i++)
                rightWall.transform.GetChild(i).gameObject.layer = 2;
        }
        if (bottomWall.enabled == true)
        {
            for (int i = 0; i < bottomWall.transform.childCount; i++)
                bottomWall.transform.GetChild(i).tag = "Land";
        }
        else
        {
            for (int i = 0; i < bottomWall.transform.childCount; i++)
                bottomWall.transform.GetChild(i).gameObject.layer = 2;
        }
        maze.Add(add);
    }
    //Breadth First Search algorithim 
    public void BFS(List<Square> maze, int[] parent, int size)
    {
        int n = (int)Mathf.Sqrt(maze.Count);
        bool[] found = new bool[size];
        for (int i = 0; i < (int)maze.Count; i++)
        {
            found[i] = false;
            parent[i] = -1;
        }
        List<int> Q = new List<int>();
        Q.Add(0);
        while (Q.Count > 0 && found[maze.Count - 1] == false)
        {
            int t = Q[0];
            if (maze[t].right == false && t != maze.Count)
                if (maze[t + 1].left == false)
                    if (!found[t + 1])
                    {
                        Q.Add(t + 1);
                        found[t + 1] = true;
                        parent[t + 1] = t;
                    }
            if (maze[t].left == false && t != 0)
                if (maze[t - 1].right == false)
                    if (!found[t - 1])
                    {
                        Q.Add(t - 1);
                        found[t - 1] = true;
                        parent[t - 1] = t;
                    }
            if (maze[t].top == false)
                if (maze[t - n].bottom == false)
                    if (!found[t - n])
                    {
                        Q.Add(t - n);
                        found[t - n] = true;
                        parent[t - n] = t;
                    }
            if (maze[t].bottom == false)
                if (maze[t + n].top == false)
                    if (!found[t + n])
                    {
                        Q.Add(t + n);
                        found[t + n] = true;
                        parent[t + n] = t;
                    }
            found[t] = true;
            Q.RemoveAt(0);
        }
    }
    public void Seek(List<Square> maze, List<int> seek, int size)
    {
        int[] found = new int[size];
        for (int i = 0; i < maze.Count; i++)
            found[i] = 0;
        List<Square> copy = maze;
        int n = (int)Mathf.Sqrt(maze.Count);
        int t = 0;
        found[0] = 1;
        while (t != maze.Count - 1)
        {
            seek.Add(t);

            int prev = t;

            bool leftOpen = false;
            bool rightOpen = false;
            bool downOpen = false;
            bool upOpen = false;

            if (copy[t].right == false && t != maze.Count)
            {
                if (copy[t + 1].left == false)
                {
                    rightOpen = true;
                }
            }
            if (copy[t].bottom == false)
            {
                if (copy[t + n].top == false)
                {
                    downOpen = true;
                }
            }
            if (copy[t].top == false)
            {
                if (copy[t - n].bottom == false)
                {
                    upOpen = true;
                }
            }
            if (copy[t].left == false && t != 0)
            {
                if (copy[t - 1].right == false)
                {
                    leftOpen = true;
                }
            }
            int least = size;
            int choice = t;
            if (rightOpen && found[t + 1] < least )
            {
                choice = t + 1;
                least = found[t + 1];
   
            }
            if (downOpen && found[t + n] < least)
            {
                choice = t + n;
                least = found[t + n];
            }
            if (upOpen && found[t - n] < least)
            {
                choice = t - n;
                least = found[t - n];
            }
            if (leftOpen && found[t - 1] < least)
            {
                choice = t - 1;
                least = found[t - 1];
            }
            t = choice;
            found[t] += 1;
            if (found[t] > 1 )
            {
                if (prev - t == 1) copy[t].SetRight(true);
                if (prev - t == n) copy[t].SetBottom(true);
                if (prev - t == -n)  copy[t].SetTop(true); 
                if (prev - t == -1) copy[t].SetLeft(true);
            }
        }
    }
    public void ClearWalls()
    {
        for (int i = 0; i < walls.Count; i++)
            Destroy(walls[i]);
        walls.Clear();
    }

    public void BuildMaze(int newSize)
    {
        sizeOfMaze = newSize;
        UnityEngine.Random.InitState(4);
        int n = sizeOfMaze;
        Maze test = new Maze(n);
        test.MakeMaze();
        List<Square> maze = new List<Square>();
        string temp = test.GetBoard();
        int xcount = 0, ycount = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            float x = transform.position.x + xcount;
            float y = transform.position.y + ycount;
            char ch = temp[i];
            AddSquare(maze, ch,x,y);
            xcount +=2;
            if ((i + 1) % n == 0)
            {
                xcount = 0;
                ycount -=2;
            }
                
        }

        int size = maze.Count;
        int[] parent = new int[size];
        BFS(maze, parent, size);//find array indexes to creat path

        List<int> seek = new List<int>();
        Seek(maze, seek, size);//find array  indexes 

        List<int> path = new List<int>();
        n = size - 1;
        path.Add(n);
        seek.Add(n);  
        while (n != 0)
        {
            path.Add(parent[n]);
            n = parent[n];
        }

        //-------------------------------------------CREATH PATHS ------------------------------------------------------
        Vector3 startingLine = new Vector3(transform.position.x -2, transform.position.y, transform.position.z);
        Vector3 finishline = new Vector3(transform.position.x + (2*sizeOfMaze), transform.position.y - (2*sizeOfMaze) + 2, transform.position.z);
        //print("BFS AKA FASTEST : " + path.Count + '\n');
        bfsPath.Add(startingLine);
        string coords = "";
        n = (int)Mathf.Sqrt(maze.Count);
        for (int i = path.Count - 1; i >= 0; i--)
        {
            float x = 2 * ((path[i] + n) % n);
            float y = transform.position.y - 2 * ((path[i] * n) / (n * n));
            float z = transform.position.z;
            Vector3 coordinate = new Vector3(x, y, z);
            bfsPath.Add(coordinate);
            coords +="(" + x + ", " + y + ")\n";
        }
        bfsPath.Add(finishline);
        //print(coords);
        coords = "";



        //print("SEEK AKA Meduim : " + seek.Count + '\n');
        seekPath.Add(startingLine);
        for (int i = 0; i < seek.Count; i++)
        {
            float x = 2* ( (seek[i] + n) % n );
            float y = transform.position.y - 2*((seek[i] * n) / (n * n));
            Vector3 coordinate = new Vector3(x, y, transform.position.z);
            seekPath.Add(coordinate);
            coords +="(" + x + ", " + y + ")\n";
        }
        coords +="(" + 2*(n - 1) + ", " + (transform.position.y - 2* (n - 1)) + ")\n";
        float lx = 2 * (n - 1); float ly = (transform.position.y - 2 * (n - 1));
        Vector3 excoordinate = new Vector3(lx, ly, transform.position.z);
        seekPath.Add(excoordinate);
        seekPath.Add(finishline);
        //print(coords);
        //print("MAZE \n\n");
        //test.PrintBoard(); 

    }

}
