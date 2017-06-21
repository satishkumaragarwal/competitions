//https://www.hackerrank.com/contests/w33/challenges/palindromic-table
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        int[][] table = new int[n][];
        for(int table_i = 0; table_i < n; table_i++){
           string[] table_temp = Console.ReadLine().Split(' ');
           table[table_i] = Array.ConvertAll(table_temp,Int32.Parse);
        }
        int[] result = Helper(table, 0, n-1, 0, m-1);
        Console.WriteLine(CalLength(result));
        Console.Write(result[0] + " " + result[2] + " " + result[1] + " " + result[3]);
    }
    
    static int[] Helper(int[][] table, int rf, int rl, int cf, int cl){
        int[] hash = new int[10];
        int[] result = new int[4];
        for(int i=rf;i<=rl;i++){
            for(int j=cf;j<=cl;j++){
                hash[table[i][j]]++;
            }
        }
        if(HasPalindrome(hash)){
            result[0] = rf; result[1] = rl; result[2] = cf; result[3] = cl;
            return result;
        }
        else {
            int[] ar = Helper(table, rf+1, rl, cf, cl);
            int[] br = Helper(table, rf, rl-1, cf, cl);
            int[] cr= Helper(table, rf, rl, cf+1, cl);
            int[] dr = Helper(table, rf, rl, cf, cl-1);
            int a = CalLength(ar), b = CalLength(br), c = CalLength(cr), d = CalLength(dr);
            int r = Math.Max(Math.Max(a,b),Math.Max(c,d));
            if(r == a)
                return ar;
            else if(r == b)
                return br;
            else if(r == c)
                return cr;
            else return dr;
        }
    }
    
    static bool HasPalindrome(int[] hash){
        int count = 0;
        foreach(var v in hash){
            if(v % 2 != 0){
                count++;
            }
        }
        
        if(count < 2){
            return true;
        }
        else {
            return false;
        }
    }
    
    static int CalLength(int[] arr){
        int result = 0;
        int rf = arr[0], rl = arr[1], cf = arr[2], cl = arr[3];
        for(int i=rf;i<=rl;i++){
            for(int j=cf;j<=cl;j++){
                result++;
            }
        }
        return result;
    }
}
