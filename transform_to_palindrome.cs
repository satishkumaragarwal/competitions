//https://www.hackerrank.com/contests/w33/challenges/transform-to-palindrome
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        int m = Convert.ToInt32(tokens_n[2]);
        MySet mset = new MySet(n);
        for(int a0 = 0; a0 < k; a0++){
            string[] tokens_x = Console.ReadLine().Split(' ');
            int x = Convert.ToInt32(tokens_x[0]);
            int y = Convert.ToInt32(tokens_x[1]);
            mset.Union(x,y);
        }
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        int[,] memo = new int[m,m];
        int count = Helper(a,0,m-1,mset,memo);
        Console.WriteLine(count);
    }
    
    static int Helper(int[] a, int i, int j, MySet mset, int[,] memo){
        if(memo[i,j] != 0) return memo[i,j];
        if(i>j) return 0;
        if(i==j) return 1;
        if(mset.Find(a[i]) == mset.Find(a[j])){
            memo[i,j] = 2+Helper(a,i+1,j-1,mset,memo);
        }
        else
            memo[i,j] = Math.Max(Helper(a,i+1,j,mset,memo),Helper(a,i,j-1,mset,memo));
        return memo[i,j];
    }
}

class MySet{
    int[] parent;
    
    public MySet(int size){
        parent = new int[size+1];
        for(int i=1;i<=size;i++){
            parent[i] = -1;
        }
    }
    
    public int Find(int u){
        if(parent[u] == -1)
            return u;
        else 
            return Find(parent[u]);
    }
    
    public void Union(int u, int v){
        int x = Find(u), y = Find(v);
        if( x!=y )
            parent[x] = Find(y);
    }
}
