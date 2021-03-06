﻿using HeartDiseaseInvestigation.DecisionTreeClassifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartDiseaseInvestigation.Model
{
    public class Patient : DatasetRow
    {
        public String id { get; set; }
        public int age { get; set; }
        public int sex { get; set; }
        public int cp { get; set; }
        public int trestbps { get; set; }
        public int chol { get; set; }
        public int fbs { get; set; }
        public int restecg { get; set; }
        public int thalach { get; set; }
        public int exang { get; set; }
        public double oldpeak { get; set; }
        public int slope { get; set; }
        public int ca { get; set; }
        public int thal { get; set; }
        public int target { get; set; }

        public Patient(string id, int age, int sex, int cp, int trestbps, int chol, int fbs, int restecg, int thalach, int exang, double oldpeak, int slope, int ca, int thal, int target)
        {
            this.id = id;
            this.age = age;
            this.sex = sex;
            this.cp = cp;
            this.trestbps = trestbps;
            this.chol = chol;
            this.fbs = fbs;
            this.restecg = restecg;
            this.thalach = thalach;
            this.exang = exang;
            this.oldpeak = oldpeak;
            this.slope = slope;
            this.ca = ca;
            this.thal = thal;
            this.target = target;
        }

        public string[] getAttributes()
        {
            String[] attributes = {""+age, "" + sex, "" + cp, "" + trestbps, "" + chol, "" + fbs, "" + restecg, "" + thalach, "" + exang, "" + oldpeak, "" + slope, "" + ca, "" + thal, "" + target };

            return attributes;
        }

        public static string[] getAttributesName()
        {
            String[] attributes = { "age", "sex", "cp", "trestbps", "chol", "fbs", "restecg", "thalach", "exang", "oldpeak", "slope", "ca", "thal", "target" };

            return attributes;
        }
    }
}
