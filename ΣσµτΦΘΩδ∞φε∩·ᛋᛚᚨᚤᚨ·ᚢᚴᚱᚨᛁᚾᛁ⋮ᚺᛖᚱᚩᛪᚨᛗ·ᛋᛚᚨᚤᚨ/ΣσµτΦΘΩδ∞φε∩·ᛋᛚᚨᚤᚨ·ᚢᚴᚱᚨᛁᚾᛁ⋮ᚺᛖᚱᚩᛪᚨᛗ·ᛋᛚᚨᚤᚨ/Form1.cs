namespace ΣσµτΦΘΩδ_φε__ᛋᛚᚨᚤᚨ_ᚢᚴᚱᚨᛁᚾᛁ_ᚺᛖᚱᚩᛪᚨᛗ_ᛋᛚᚨᚤᚨ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        object[] arrays_of_training_data = new object[0];
        object?[] predicting_data = new object[0];

        decimal[] probability = new decimal[0];
        string[] types = new string[0];
        decimal[] average = new decimal[0];

        int predicting_cell_num = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            object[] temp_arrays_of_training_data = textBox2.Text.Split("\r\n");
            arrays_of_training_data = new object[temp_arrays_of_training_data.Length];
            object[] temp_predicting_data = textBox3.Text.Split(" ");
            predicting_data = new object[temp_predicting_data.Length];

            for (int i = 0; i < predicting_data.Length; i++)
            {
                if (temp_predicting_data[i] == "")
                {
                    predicting_cell_num = i;
                }

                if (decimal.TryParse((string?)temp_predicting_data[i], out decimal result))
                {
                    predicting_data[i] = result;
                }

                else
                {
                    predicting_data[i] = temp_predicting_data[i];
                }
            }

            for (int i = 0; i < temp_arrays_of_training_data.Length; i++)
            {
                string[] temp2 = ((string)temp_arrays_of_training_data[i]).Split(" ");

                arrays_of_training_data[i] = new decimal[temp2.Length];

                for (int j = 0; j < temp2.Length; j++)
                {
                    if (decimal.TryParse((string)temp2[j], out decimal result))
                    {
                        ((decimal[])arrays_of_training_data[i])[j] = result;
                    }

                    else
                    {
                        arrays_of_training_data[i] = new string[temp2.Length];

                        for (int k = 0; k < temp2.Length; k++)
                        {
                            ((object[])arrays_of_training_data[i])[k] = temp2[k];
                        }

                        break;
                    }
                }
            }

            AI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //string[] a = File.ReadAllText(@"C:\Users\james\Documents\iris.txt").Split("\r\n");
            //string[] b = a[0].Split(" ");

            //arrays_of_training_data = new object[b.Length];
            //predicting_data = new object[b.Length];

            //for (int i = 0; i < b.Length; i++)
            //{
            //    if (decimal.TryParse(b[i], out decimal result))
            //    {
            //        arrays_of_training_data[i] = new decimal[a.Length];

            //        for (int j = 0; j < a.Length; j++)
            //        {
            //            string[] t = a[j].Split(" ");
            //            decimal c = Convert.ToDecimal(t[i]);

            //            ((decimal[])arrays_of_training_data[i])[j] = c;
            //        }

            //    }

            //    else
            //    {
            //        arrays_of_training_data[i] = new string[a.Length];

            //        for (int j = 0; j < a.Length; j++)
            //        {
            //            string[] c = a[j].Split(" ");

            //            ((string[])arrays_of_training_data[i])[j] = c[i];
            //        }
            //    }
            //}

            //arrays_of_training_data[0] = new decimal[5] { 27, 48, 33, 30, 66 }; // age
            //arrays_of_training_data[1] = new decimal[5] { 24000, 98000, 44000, 29000, 65000 }; // salary
            //arrays_of_training_data[2] = new string[5] { "F", "M", "M", "F", "M" }; // gender
            //arrays_of_training_data[3] = new string[5] { "Pres", "Cath", "Other", "Cath", "Pres" }; // religion
            //arrays_of_training_data[4] = new string[5] { "Dem", "Rep", "Rep", "Ind", "Dem" }; // political stance

            //predicting_data[0] = (decimal)5.9; // sepal_length 5.9
            //predicting_data[1] = (decimal)3.0; // sepal_width 3.0
            //predicting_data[2] = (decimal)5.1; // petal_length 5.1
            //predicting_data[3] = (decimal)1.8; // petal_width 1.8
            //predicting_data[4] = null; // species virginica

            //predicting_cell_num = 0; // predict species using probability

            //arrays_of_training_data = new object[a.Length];
            //predicting_data = new object[a.Length];

            //arrays_of_training_data[0] = new decimal[5] { 27, 48, 33, 30, 66 }; // age
            //arrays_of_training_data[1] = new decimal[5] { 24000, 98000, 44000, 29000, 65000 }; // salary
            //arrays_of_training_data[2] = new string[5] { "F", "M", "M", "F", "M" }; // gender
            //arrays_of_training_data[3] = new string[5] { "Pres", "Cath", "Other", "Cath", "Pres" }; // religion
            //arrays_of_training_data[4] = new string[5] { "Dem", "Rep", "Rep", "Ind", "Dem" }; // political stance

            //predicting_data[0] = (decimal)38; // age
            //predicting_data[1] = (decimal)51000; // salary
            //predicting_data[2] = (string)"M"; // gender
            //predicting_data[3] = (string)"Pres"; // religion
            //predicting_data[4] = ""; // political stance

            //predicting_cell_num = 4; // predict political stance using probability
        }

        public void AI()
        {


            if (arrays_of_training_data[predicting_cell_num] is string[])
            {
                types = new string[1] { ((string[])arrays_of_training_data[predicting_cell_num])[0] };

                for (int i = 0; i < ((string[])arrays_of_training_data[predicting_cell_num]).Length; i++)
                {
                    bool new_ = true;

                    for (int j = 0; j < types.Length; j++)
                    {
                        if (types[j] == ((string[])arrays_of_training_data[predicting_cell_num])[i])
                        {
                            new_ = false;
                            break;
                        }
                    }

                    if (new_)
                    {
                        Array.Resize(ref types, types.Length + 1);

                        types[types.Length - 1] = ((string[])arrays_of_training_data[predicting_cell_num])[i];
                    }
                }

                probability = new decimal[types.Length];

                decimal divide_probability_by = arrays_of_training_data.Length - 1;

                for (int i = 0; i < arrays_of_training_data.Length; i++)
                {
                    if (i != predicting_cell_num)
                    {
                        if (arrays_of_training_data[i] is decimal[])
                        {
                            decimal[] temp = (decimal[])arrays_of_training_data[i];

                            // now find the probability in temp

                            // first find the closest number in the array to ours

                            decimal min = temp[0];

                            for (int j = 1; j < temp.Length; j++)
                            {
                                if (Math.Abs((decimal)predicting_data[i] - min) > Math.Abs((decimal)predicting_data[i] - temp[j]))
                                {
                                    min = temp[j];
                                }
                            }

                            // now express all the other training data with it

                            decimal denominator = 0;

                            for (int j = 0; j < temp.Length; j++)
                            {
                                if (min < temp[j])
                                {
                                    denominator = denominator + 1 / (temp[j] / min);
                                }

                                else
                                {
                                    denominator = denominator + 1 / (min / temp[j]);
                                }
                            }

                            decimal numerator = 0;

                            // find the probability in temp

                            decimal[] temp_probability = new decimal[types.Length];

                            for (int j = 0; j < temp_probability.Length; j++)
                            {
                                temp_probability[j] = 0;
                            }

                            for (int j = 0; j < temp.Length; j++)
                            {
                                for (int k = 0; k < types.Length; k++)
                                {
                                    if (types[k] == ((string[])arrays_of_training_data[predicting_cell_num])[j])
                                    {
                                        if (min < temp[j])
                                        {
                                            numerator = 1 / (temp[j] / min);
                                        }

                                        else
                                        {
                                            numerator = 1 / (min / temp[j]);
                                        }

                                        temp_probability[k] = temp_probability[k] + numerator / denominator;
                                    }
                                }
                            }

                            for (int k = 0; k < types.Length; k++)
                            {
                                probability[k] = probability[k] + temp_probability[k];
                            }
                        }

                        if (arrays_of_training_data[i] is string[])
                        {
                            bool no_such_type = true;

                            decimal[] temp_probability = new decimal[types.Length];
                            decimal total_num = 0;

                            for (int j = 0; j < ((string[])arrays_of_training_data[i]).Length; j++)
                            {
                                if (predicting_data[i] == ((string[])arrays_of_training_data[i])[j])
                                {
                                    no_such_type = false;

                                    // finding the probability

                                    int k = 0;

                                    for (int l = 0; l < types.Length; l++)
                                    {
                                        if (((string[])arrays_of_training_data[predicting_cell_num])[j] == types[l])
                                        {
                                            k = l;
                                            break;
                                        }
                                    }

                                    temp_probability[k]++;
                                    total_num++;
                                }
                            }

                            if (no_such_type)
                            {
                                divide_probability_by--;
                            }

                            else
                            {
                                for (int j = 0; j < temp_probability.Length; j++)
                                {
                                    // finding the probability

                                    temp_probability[j] = temp_probability[j] / total_num;

                                    // adding the probability

                                    probability[j] = probability[j] + temp_probability[j];
                                }
                            }
                        }
                    }
                }

                textBox1.Text = "";

                for (int j = 0; j < probability.Length; j++)
                {
                    probability[j] = probability[j] / divide_probability_by;

                    textBox1.Text = textBox1.Text + types[j] + " " + probability[j].ToString() + "\r\n";
                }
            }


            // if we have to predict a number
            else
            {
                //  44k * 1, 65k * 0.6, 96k * 0.2 ...

                average = new decimal[arrays_of_training_data.Length];

                decimal divide_average_by = arrays_of_training_data.Length - 1;

                for (int i = 0; i < arrays_of_training_data.Length; i++)
                {
                    if (i != predicting_cell_num)
                    {
                        if (arrays_of_training_data[i] is decimal[]) // the way to do it is ((38 - 33) / 5 * 44000 + (44 - 5 / (38 - 27) * 24000) + (44000 + 5 / (48 - 38) * 98000) + (44000 - 5 / (38 - 30) * 29000) + (44000 + 5 / (66 - 38) * 65000)) / 5
                        {
                            decimal[] temp = (decimal[])arrays_of_training_data[i];
                            int[] temp_index = new int[0];

                            // now find the predicted average number in temp

                            // first find the closest number in the array to ours and express it as 1, so we value 100% of it

                            decimal min = temp[0];

                            for (int j = 1; j < temp.Length; j++)
                            {
                                if (Math.Abs((decimal)predicting_data[i] - min) > Math.Abs((decimal)predicting_data[i] - temp[j]))
                                {
                                    min = temp[j];
                                }
                            }

                            // now express all the other training data with it

                            decimal numerator = 0;

                            for (int j = 0; j < temp.Length; j++)
                            {
                                if (min < temp[j])
                                {
                                    numerator = numerator + ((decimal[])arrays_of_training_data[predicting_cell_num])[j] * (1 / (temp[j] / min));
                                }

                                else
                                {
                                    numerator = numerator + ((decimal[])arrays_of_training_data[predicting_cell_num])[j] * (1 / (min / temp[j]));
                                }
                            }

                            decimal denominator = temp.Length;

                            // find the average in temp

                            decimal temp_average = numerator;
                            temp_average = numerator / denominator;

                            average[i] = temp_average;
                        }

                        else
                        {
                            bool no_such_type = true;

                            decimal temp_average = 0;
                            decimal total_num = 0;

                            for (int j = 0; j < ((string[])arrays_of_training_data[i]).Length; j++)
                            {
                                if ((string)predicting_data[i] == ((string[])arrays_of_training_data[i])[j])
                                {
                                    no_such_type = false;

                                    // finding the average

                                    average[i] = average[i] + ((decimal[])arrays_of_training_data[predicting_cell_num])[j];
                                    total_num++;
                                }
                            }

                            if (no_such_type)
                            {
                                divide_average_by--;
                            }

                            else
                            {
                                // finding the average

                                average[i] = average[i] / total_num;
                            }
                        }
                    }
                }

                // final average

                decimal t = 0;

                for (int i = 0; i < average.Length; i++)
                {
                    t = t + average[i];
                }

                decimal answer = t / divide_average_by;

                textBox1.Text = answer.ToString();
            }
        }
    }
}