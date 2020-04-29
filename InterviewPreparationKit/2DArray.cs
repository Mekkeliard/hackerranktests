using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the hourglassSum function below.
    static int hourglassSum(int[][] arr) {
        var result = Method(0,0,arr);
        for(var i = 0; i < arr.Length - 2; i++)
            for(var j = 0; j < arr.Length - 2; j++){
                var sum = Method(i, j, arr);
                if(sum > result) result = sum;
            }
        return result;
    }

    static int Method(int beginH, int beginW, int[][] arr){
        var result = 0;
        for(int i = beginH; i < beginH+3; i++)
            for(int j = beginW; j < beginW+3; j++)
            {
                result += arr[i][j];
            }
        result -= arr[beginH+1][beginW] + arr[beginH+1][beginW+2];
        return result;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] arr = new int[6][];

        for (int i = 0; i < 6; i++) {
            arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
        }

        int result = hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
