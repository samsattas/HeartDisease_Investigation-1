﻿using HeartDiseaseInvestigation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartDiseaseInvestigation.DecisionTreeClassifier
{
    class DecisionTree<T> where T: DatasetRow
    {
        private Node root { get; set; }
        private DataTable dataset { get; set; }
        private Dictionary<String, T> datasetDictionary { get; set; }

        public DecisionTree(Dictionary<String, T> dataset)
        {
            this.datasetDictionary = dataset;
        }

        private Dictionary<String, Int32> CountLabelDistribution(List<T> rows)
        {
            Dictionary<String, Int32> distribution = new Dictionary<String, Int32>();

            foreach (T row in rows)
            {
                String[] attributes = row.getAttributes();

                //We supose that the last attribute it's our label.
                String label = attributes[attributes.Length - 1];

                if (distribution.Keys.Contains(label))
                {
                    distribution[label] +=1;
                }
                else
                {
                    distribution.Add(label, 0);
                }

            }

            return distribution;
        }

        public List<T>[] Partition(Query<T> query)
        {
            List<T>[] partition = {new List<T>(), new List<T>()};

            foreach (String key in datasetDictionary.Keys)
            {
                T row = this.datasetDictionary[key];

                if (query.Compare(row))
                {
                    partition[0].Add(row);
                }
                else
                {
                    partition[1].Add(row);
                }
            }


            return partition;
        }

        public double Gini(List<T> rows)
        {
            double impurity = 1;

            Dictionary<String, Int32> distribution = this.CountLabelDistribution(rows);

            foreach (String label in distribution.Keys)
            {
                double prob = distribution[label] / rows.Count;
                impurity -= Math.Pow(prob, 2) ;
            }

            return impurity;
        }

        public double InformationGain(List<T> left, List<T> right, double impurity)
        {

            double proportion = Convert.ToDouble(left.Count) / (Convert.ToDouble(left.Count)+ Convert.ToDouble(right.Count));

            return impurity - proportion * this.Gini(left) - (1 - proportion) * this.Gini(right);
        }

    }
}
