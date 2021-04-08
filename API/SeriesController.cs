using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StatementHCL.API
{
    public class SeriesController : ApiController
    {
        [HttpGet]
        public int[] GetSeries(int term, int division, int position)
        {

            term++;
            int[] arrseries = new int[term];
            arrseries = Series(term);
            int output= Devision(term, division, position,arrseries);
            //find division on given position
            int LastArrayindex = arrseries.GetUpperBound(0);
            arrseries[LastArrayindex] = output; //storing division number at last index of array
            return arrseries;
        }

        //=============Generating Series============
        public int[] Series(int term)
        {
            int[] arrseries = new int[term];
            // arr[0] = 1;
            // arr[1] = 1;
            // arr[2] = 1;
            for (int _index = 0; _index < term-1; _index++)
            {
                if (_index < 3)
                {
                    //placing 1 on first 3 index
                    arrseries[_index] = 1;
                }
                else
                {
                    int lastIndex = _index - 1, sum = 0;
                    // Find the sum of previous 3 number
                    for (int k = 0; k < 3; k++)
                    {
                        sum = sum + arrseries[lastIndex];
                        lastIndex--;
                    }

                    //The value of sum at _index position
                    arrseries[_index] = sum;  //Series is generating
                }
            }
            return arrseries;
        }

        //===========finding division on given number ===========
        public int Devision(int term, int division, int position,int[] arrseries)
        {
            //int[] arrserries = new int[term];
            int[] arrDevision = new int[term]; //Array to store divisible number
            int val = 0;
            int Div_pos = 1;
            //placing all devisible number in array position start with 1
            for (int index_ = 0; index_ < term; index_++)
            {
                val = arrseries[index_];
                if (val % division == 0)
                {
                    arrDevision[Div_pos] = arrseries[index_];
                    Div_pos++;
                }
            }
            int output = arrDevision[position];
            return output;
        }

        [HttpGet]
        public int GetSum(int iteration)
        {

            int sum = 0,flag = 0;
            // try
            //{
            if (iteration == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                int[] arrElement = new int[] { 1, 2, 3, 4, 5 };
                int sumOfLast = 0;
                //Rotate the given array by n times toward left  
                for (int index = 0; index < iteration; index++)
                {
                    int j, first_val;
                    //Stores the first element of the array  
                    first_val = arrElement[0];
                    for (j = 0; j < arrElement.Length - 1; j++)
                    {
                        //Shift element of array by one  
                        arrElement[j] = arrElement[j + 1];
                    }
                    //First element of array will be added to the end  
                    arrElement[j] = first_val;
                    sum = arrElement[0] + arrElement[1];
                }

                sumOfLast = arrElement[3] + arrElement[4];
                if (arrElement[0] == sumOfLast)
                {
                    //// return 0;
                    throw new HttpResponseException(HttpStatusCode.NotFound); 
                }
                else
                {
                    return sum;
                }
            }
          /*  int[] arrElement = new int[] { 1, 2, 3, 4, 5 };
            int sumOfLast = 0;
                //Rotate the given array by n times toward left  
                for (int index = 0; index < iteration; index++)
                {
                    int j, first_val;
                    //Stores the first element of the array  
                    first_val = arrElement[0];
                    for (j = 0; j < arrElement.Length - 1; j++)
                    {
                        //Shift element of array by one  
                        arrElement[j] = arrElement[j + 1];
                    }
                    //First element of array will be added to the end  
                    arrElement[j] = first_val;
                    sum = arrElement[0] + arrElement[1];
                }

            sumOfLast = arrElement[3] + arrElement[4];
            if (arrElement[0] == sumOfLast)
            {
                return 0;
            }
            else
            {
                return sum;
            }
               */
            //}
            //catch (Exception e)
            //{
            //    string Message = e.Message;
            //    flag++;
            //}
            //if (flag == 1)
            //{
            //    return 0;
            //}
            //else
            //{
            //    return sum;
            //}
        }
    }
}
