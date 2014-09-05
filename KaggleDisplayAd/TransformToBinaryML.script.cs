using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;

public class DisplayAdDataExtractor : Extractor {

    public override Schema Produces(string[] columns, string[] args) {
        string s = "age:int, workclass:string, fnlwgt:int, education:string, educationnum:int, maritalstatus:string, occupation:string, relationship:string, race:string, sex:string, capitalgain:int, capitalloss:int, hpw:int, natcountry:string, income:string";
        return new Schema(s);
    }


    public override IEnumerable<Row> Extract(StreamReader reader, Row output, string[] args)
    {
        string[] mean = new[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "" }; // mean[i] is the mean of L[i]
        string line;
        while ((line = reader.ReadLine()) != null) {
            if (false == string.IsNullOrEmpty(line) && false == line.Contains("?") && false == line.Contains("Id")) {
                string[] tokens = line.Split(',');

                for (int i = 0; i < tokens.Length; ++i) {
                    if (string.IsNullOrEmpty(tokens[i]))
                    {
                        if (i >= 2 && i <= 14)
                        {
                            output[i].Set(mean[i - 1]);
                        }
                        else
                        {
                            output[i].Set("NA".Trim());
                        }
                    }
                    else
                    {
                        output[i].Set(tokens[i].Trim());
                    }
                }
                yield return output;
            }

        }
    }
}
