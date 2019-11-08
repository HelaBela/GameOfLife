using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class UserGridProvider:IGridStateProvider
    {

        private ICommunicationOperations _communicationOperations;

        public UserGridProvider(ICommunicationOperations communicationOperations)
        {
            _communicationOperations = communicationOperations;
        }

        public int[,] GetGridState()
        {
            _communicationOperations.WriteLine("Provide initial cell state in the following format:' 0010,1000,1100,000 ' where 1 mean the cell is alive and 0 means cell is dead. ");

            
                var userAnswer = _communicationOperations.Read();
                
                var userAnswerArray = userAnswer.Split(',').ToArray();
            
                var userAnswerAsTwoDArray = new int[userAnswerArray.Length, userAnswerArray.Length];

                for (var i=0; i<userAnswerArray.Length; i++)
                {
                    for (var j = 0; j < userAnswerArray[i].Length; j++)
                    {
                        userAnswerAsTwoDArray[i, j] = int.Parse(userAnswerArray[i][j].ToString());
                    }

                }
            
                return userAnswerAsTwoDArray;

            }


        }
    }
