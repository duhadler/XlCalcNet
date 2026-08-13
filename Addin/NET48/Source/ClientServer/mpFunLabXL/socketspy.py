# -*- coding: utf-8 -*-


#See also: https://stackoverflow.com/questions/42680413/connecting-python-socketserver-with-c-sharp-client

from os import system
system("title " + "xlcalcnet socket server 64 bit on port 11958")

import socketserver
import socket
import sys, os, platform, math
import traceback, subprocess
import datetime as dt
from os import system
#from mpaddin import *



def spreadsheet_date(date1):
    temp = dt.datetime(1899, 12, 30)    # Note, not 31st Dec but 30th!
    delta = date1 - temp
    return float(delta.days) + (float(delta.seconds) / 86400)


def getmatB():

    dt1 = dt.datetime(1999, 12, 20)
    dt2 = dt.datetime(1942, 2, 4)
    dt3 = dt.datetime(2022, 8, 14)
    matB = [[99, 20, 300], \
            [11.340, 62.980, 83.930], \
            [dt1, dt2, dt3], \
            [True, False, True], \
            ['ABC_1.0', 'DEF_2.0', 'GHI_3.0']]
    return matB


def getmatA():
    matA = [99, 20, 300]
    return matA



def getmatC():
    matA = [[99], [20], [300]]
    return matA



def List2String(matB):
    if isinstance(matB[0], str):
        matB = [matB]
    try:
        iter(matB[0])
    except TypeError:
        matB = [matB]
    globallist = ["$list$"]
    for item1 in matB:
        #print(item1)
        locallist = []
        for item2 in item1:
            #print(item2, type(item2), isinstance(item2, int))
            res = ""
            if isinstance(item2, dt.datetime):
                #res = "$datetime$" + str(item2)
                res = "$datetime$" + str(spreadsheet_date(item2))
            elif isinstance(item2, bool):
                res = "$bool$" + str(item2)
            elif (isinstance(item2, float) or isinstance(item2, int)):
                res = "$float$" + str(item2)
            else:
                res = str(item2)
            locallist.append(res)
            #print(res)
        #print("locallist: \n", locallist)
        strlist = '§_§'.join(locallist)
        #print("strlist: \n", strlist)
        globallist.append(strlist)

    #print("globallist: \n", globallist)
    strgloballist = '§__§'.join(globallist)
    #print(strgloballist)
    return strgloballist



def String2List(instr):
    globallist = []
    t = instr.split("§__§")
    #print(t)
    for i in range(1, len(t)):
        #print( "\n", t[i])
        ts = t[i].split("§_§")
        #print(ts)
        for j in range(len(ts)):
            #print(ts[j])
            if ts[j].startswith("$float$"):
                ts[j] = float(ts[j][7:])
            elif ts[j].startswith("$datetime$"):
                ts[j] = float(ts[j][10:])
            elif ts[j].startswith("$bool$"):
                if ts[j] == "$bool$True": ts[j] = True
                else: ts[j] = False
            #print(ts[j], type(ts[j]))
        print(ts)
        globallist.append(ts)
    return globallist



def reformat(Formula):
    FinalString = ""
    FLines = Formula.split(r"$n")
    for FLine in FLines:
        FLineList = FLine.split(r"$t")
        FLen = len(FLineList)-1
        FLine = FLineList[FLen]
        FLine = FLine.strip()
        if FLen>0:
            for i in range(FLen):
                FinalString += '\t'
        FinalString += FLine + '\n'
    return FinalString



def rxc(P1):
	if isinstance(P1, str):
		return 'R1xC1'
	if hasattr(P1, '__iter__'):
		if isinstance(P1[0], str):
			return 'R1xC' + str(len(P1))
		elif hasattr(P1[0], '__iter__'):
			return 'R' + str(len(P1)) + 'xC' +  str(len(P1[0]))
		else:
			return 'R1xC' + str(len(P1))
	else:
		return 'R1xC1'
	return "Error: input is not a scalar, a vector, or a matrix"



def pyexec_instr(instr):
    try:
        #print("instr: ", instr)
        Params = instr.split("||")
        Formula = reformat(Params[0])
        localdict = {}
        for i in range(1, len(Params)):
            Param = Params[i]
            #print("before: ", Param)
            if Param.startswith("$float$"):
                #print("in startswith")
                Param = float(Param[7:])
                #print("after: ", Param)
            if Param.startswith("$list$"):
                #print("in startswith", Param)
                Param = String2List(Param)
                #print("after: ", Param)
            localdict["P"+(str(i)).strip()] = Param
        exec(Formula, globals(), localdict)
        return localdict['result']
    except Exception as e:
        return  'Exception: ' + str(e)



class xlcalcnetTCPHandler(socketserver.BaseRequestHandler):

    def handle(self):
        self.data = self.request.recv(1024).strip()
        #print ("{} wrote:".format(self.client_address[0]))
        #print (self.data, type(self.data))
        instr = self.data.decode('utf-8')
        #print(instr)
        res = pyexec_instr(instr)
        my_str = ""
        if isinstance(res, list):
            my_str = List2String(res)
        elif isinstance(res, dt.datetime):
            my_str = "$datetime$" + str(spreadsheet_date(res))
        elif isinstance(res, bool):
            my_str = "$bool$" + str(res)
        elif (isinstance(res, float) or isinstance(res, int)):
            my_str = "$float$" + str(res)
        else:
            my_str = str(res)
        #print("my_str:", my_str, type(my_str))
        my_str_as_bytes = my_str.encode(encoding='utf-8')
        #print("my_str_as_bytes: ", my_str_as_bytes, type(my_str_as_bytes))
        self.request.sendall(my_str_as_bytes)

if __name__ == "__main__":
    HOST, PORT = socket.gethostname(), 11958

    server = socketserver.TCPServer((HOST, PORT), xlcalcnetTCPHandler)
    server.serve_forever()
    
    