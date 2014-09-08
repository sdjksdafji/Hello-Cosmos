using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;

public class DisplayAdDataTestingExtractor : Extractor {

    public override Schema Produces(string[] columns, string[] args) {
        string s = "Id:string, I1:long, I2:long, " +
                   "I3:long, I4:long, I5:long, I6:long, I7:long, " +
                   "I8:long, I9:long, I10:long, I11:long, I12:long, " +
                   "I13:long, C1:string, C2:string, C3:string, C4:string, " +
                   "C5:string, C6:string, C7:string, C8:string, C9:string, C10:string, " +
                   "C11:string, C12:string, C13:string, C14:string, C15:string, " +
                   "C16:string, C17:string, C18:string, C19:string, C20:string, " +
                   "C21:string, C22:string, C23:string, C24:string, C25:string, C26:string";
        return new Schema(s);
    }


    public override IEnumerable<Row> Extract(StreamReader reader, Row output, string[] args) {
        string[] mean = new[] { "", "4", "106", "27", "7", "18539", "116", "16", "13", "106", "1", "3", "1", "8" }; // mean[i] is the mean of I[i]
        string line;
        while ((line = reader.ReadLine()) != null) {
            if (false == string.IsNullOrEmpty(line) && false == line.Contains("?") && false == line.Contains("Id")) {
                string[] tokens = line.Split(',');

                for (int i = 0; i < tokens.Length; ++i) {
                    if (string.IsNullOrEmpty(tokens[i])) {
                        if (i >= 1 && i <= 13) {
                            output[i].Set(mean[i].Trim());
                        } else {
                            output[i].Set("NA".Trim());
                        }
                    } else {
                        output[i].Set(tokens[i].Trim());
                    }
                }
                yield return output;
            }

        }
    }
}
