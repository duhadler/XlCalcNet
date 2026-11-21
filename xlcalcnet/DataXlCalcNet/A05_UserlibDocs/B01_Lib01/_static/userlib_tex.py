
    

import os

FullFilePath = os.path.realpath(__file__)

print("FullFilePath: ", FullFilePath)

LocalDir = os.path.dirname(FullFilePath)

print("LocalDir: ", LocalDir)


in1 = LocalDir + r"\latex\userlib.tex"
in2 = LocalDir + r"\Copyright_And_Preface.tex"
out1 = LocalDir + r"\latex\Temp.tex"

print("in1: ", in1)
print("in2: ", in2)
print("out1: ", out1)


fileHandler1 = open (in1, mode = "r", encoding="utf-8")
fileHandler2 = open (in2, mode = "r", encoding="utf-8")
writer = open (out1,  mode = "w", encoding="utf-8")


# Get list of all lines in files
listOfLines1 = fileHandler1.readlines()
listOfLines2 = fileHandler2.readlines()


# Iterate over the lines
Searching_Start = True
Searching_End = True
NeedsInsert = True
for line1 in listOfLines1:
    #curline = line1.strip()
    curline = line1
#    print(curline)
    if Searching_Start:
        #print("curline: ", curline)
        if r"\begin{document}" in curline:
#            print("Found Searching_Start! ")
#            print("final1: ", curline)
            writer.write(curline)
            Searching_Start = False
        else: 
#            print("final1: ", curline)
            writer.write(curline)
    else:
        if NeedsInsert:
            NeedsInsert = False
            for line2 in listOfLines2:
                #curline2 = line2.strip()
                curline2 = line2
#                print("final2: ", curline2)
                writer.write(curline2)

        if Searching_End:
            #print(curline)
            if r"\part{Getting started}" in curline:
#                print("!Found Searching_End:  ")
#                print("final3: ", curline)
                writer.write(curline)
                Searching_End = False
#            else:
#                print("skipping: ", curline)
        else:
#            print("final3: ", curline)
            writer.write(curline)
        

# Close files 
fileHandler1.close()
fileHandler2.close()
writer.close()

os.remove(in1)
os.rename(out1, in1)
