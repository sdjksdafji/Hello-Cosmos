using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ScopeRuntime;

public class StringExtractor : Extractor {

    public override Schema Produces(string[] columns, string[] args) {
        string s = "Id:string, Label:string, I1:string, I2:string, " +
                   "I3:string, I4:string, I5:string, I6:string, I7:string, " +
                   "I8:string, I9:string, I10:string, I11:string, I12:string, " +
                   "I13:string, C1:string, C2:string, C3:string, C4:string, " +
                   "C5:string, C6:string, C7:string, C8:string, C9:string, C10:string, " +
                   "C11:string, C12:string, C13:string, C14:string, C15:string, " +
                   "C16:string, C17:string, C18:string, C19:string, C20:string, " +
                   "C21:string, C22:string, C23:string, C24:string, C25:string, C26:string";
        return new Schema(s);
    }


    public override IEnumerable<Row> Extract(StreamReader reader, Row output, string[] args) {

        string line;
        while ((line = reader.ReadLine()) != null) {
            if (false == string.IsNullOrEmpty(line) && false == line.Contains("?") && false == line.Contains("Id")) {
                string[] tokens = line.Split(',');

                for (int i = 0; i < tokens.Length; ++i) {
                    output[i].Set(tokens[i].Trim());
                }
                yield return output;
            }

        }
    }
}
