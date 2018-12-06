using System;

namespace BigNumberAdd
{
    public class AdditionLogicClass
    {
        private string num1;
        private string num2;

        public AdditionLogicClass(string num1, string num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public string AddingNumbers()
        {
            int[] num1Int = ConvertToIntArray(num1);
            int[] num2Int = ConvertToIntArray(num2);
            foreach(int num in num1Int)
            {
                //Console.Write(num);
            }
            string resultFinal = "";
            if(num1Int.Length>num2Int.Length)
            {
                num2Int = arraEqual(num1Int.Length, num2Int);
            }
            else if(num2Int.Length>num1Int.Length)
            {
                num1Int = arraEqual(num2Int.Length, num1Int);
            }
            int[] result = new int[num1Int.Length>num2Int.Length?num1Int.Length : num2Int.Length];
            int indexOfNum1 = num1Int.Length - 1;
            int indexOfNum2 = num2Int.Length - 1;
            int resultIndex = result.Length - 1;
            int carry = 0;
            while (indexOfNum1 >=0 & indexOfNum2>=0)
            {

                //Console.WriteLine("in while");
                int[] arrOfCarry = new int[2];
                arrOfCarry = calculatioProc(num1Int[indexOfNum1], num2Int[indexOfNum2], carry);
                result[resultIndex] = arrOfCarry[0];
                carry = arrOfCarry[1];
                //Console.WriteLine(num1Int[indexOfNum1] + " " + num2Int[indexOfNum2] +" "+ arrOfCarry[0]+" "+ arrOfCarry[1]);
                resultIndex--;
                indexOfNum1--;
                indexOfNum2--;
                
            }

            if (carry != 0)
            {
                result = reInitializeArray(result);
                result[0] = carry;
            }

            foreach(int number in result)
            {
                resultFinal += number;
            }
            return resultFinal;
        }

        private int[] reInitializeArray(int[] result)
        {
            int[] temp = new int[result.Length + 1];
            int i = temp.Length - 1;
            int j = result.Length - 1;

            while(i>=0)
            {
                
                if(j>=0)
                {
                    temp[i] = result[j];
                    i--;
                    j--;
                }
                else
                {
                    temp[i] = 0;
                    i--;
                   // j = 0;
                }
            }
            return temp;
        }

        private int[] arraEqual(int length, int[] result)
        {
            int[] temp = new int[length];
            int i = temp.Length - 1;
            int j = result.Length - 1;

            while (i >= 0)
            {

                if (j >= 0)
                {
                    temp[i] = result[j];
                   // Console.WriteLine("thi"+result[j]);
                    i--;
                    j--;
                }
                else
                {
                    temp[i] = 0;
                    i--;
                    //j = 0;
                }
            }
            foreach(int n in temp)
            {
               // Console.WriteLine( "testing array " + n + " length " + length + " equal "+ result.Length);
            }
            return temp;
        }

        private int[] calculatioProc(int v1, int v2, int carry)
        {
            int sum = v1 + v2 + carry;
            int addValue = 0;
            //Console.WriteLine(sum);
            if(sum>9)
            {
                addValue = sum % 10;
                carry = sum / 10;
            }
            else
            {
                addValue = sum;
                carry = 0;
            }

            int[] returningArray = { addValue, carry };
            return returningArray;
        }

        private int[] ConvertToIntArray(string num1)
        {
            char[] tempCharArr = num1.ToCharArray();
            int[] convertedArray = new int[tempCharArr.Length];
            int counter = 0;
            foreach(char ch in tempCharArr)
            {
                string temp = "";
                temp += ch;
                convertedArray[counter] = int.Parse(temp);
                //Console.WriteLine(ch);
                counter++;
            }

            return convertedArray;
        }
    }
}