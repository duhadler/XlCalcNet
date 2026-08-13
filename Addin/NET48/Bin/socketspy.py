# -*- coding: utf-8 -*-


#See also: https://stackoverflow.com/questions/42680413/connecting-python-socketserver-with-c-sharp-client

from os import system
#system("title " + "xlcalcnet socket server 64 bit on port 11958")
system("title " + "xlcalcnet socket server 64 bit")

import socketserver
import socket
import sys, os, platform, math
import traceback, subprocess, pkgutil
import datetime as dt
from os import system
from xlcalcnet import *
from xlcalcnet import gui; gui.adduserpath()
print("Start of socketserver completed")



def list_toplevel_modules():
    for p in pkgutil.iter_modules():
        print(p[1])


def list_callables():
    import sys
    for name, test in sys.__dict__.items():
        if callable(test):
            print(name)

def list_nounderscore():
    import sys
    for name, test in sys.__dict__.items():
        if not name.startswith('_'):
            print(name)


def getfuncnames(ctxstr):
    from xlcalcnet import mpm, ivm, dpm
    if ctxstr == 'mpm': ctx = mpm
    if ctxstr == 'ivm': ctx = ivm
    if ctxstr == 'dpm': ctx = dpm
    rlist = dir(ctx)
    sentence = "|".join(rlist)
    print(sentence)



def list_ctx(ctxstr):
    from xlcalcnet import mpm, ivm, dpm
    from inspect import signature
    
    def getprop(ctx, ctxstr, prop):
        #s = 'type(' + ctxstr + ').' + prop
        s = 'type(ctx).' + prop
        
        return eval(s)

    if ctxstr == 'mpm': ctx = mpm
    if ctxstr == 'ivm': ctx = ivm
    if ctxstr == 'dpm': ctx = dpm
    
    rlist = dir(ctx)
    print(len(rlist))
    for name in rlist:
        if not (name.startswith('_') or name.endswith('_')):
            func = getattr(ctx, name)
            if callable(func):
                sig = signature(func)
                print(name, type(func), sig, func.__doc__)
            else:
                res = getprop(ctx, ctxstr, name)
                print(name, type(res) , res.__doc__)




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
        #print(ts)
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
            elif Param.startswith("$list$"):
                #print("in startswith", Param)
                Param = String2List(Param)
                #print("after: ", Param)
            elif Param.startswith("$bool$"):
                if Param == "$bool$True": Param = True
                else: Param = False
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
        #print("instr: ", instr)

        if instr.startswith("$file:$"):
            print("python: read from file")
            in1 = r"C:\Temp\FileTempIn.txt"
            file = open (in1, mode = "r", encoding="utf-8")
            instr = file.read()
            file.close()
            print("instr: ", instr)

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
        print("my_str:", my_str, type(my_str))

        TotalBytesThreshold = 1000
        #TotalBytesThreshold = 1
        my_str_as_bytes = my_str.encode(encoding='utf-8')
        TotalBytes = len(my_str_as_bytes)
        print("TotalBytes: ", TotalBytes)

        if TotalBytes > TotalBytesThreshold:
            print("python: write to file")
            out1 = r"C:\Temp\FileTempOut.txt"
            writer = open (out1,  mode = "w", encoding="utf-8")
            writer.write(my_str)
            writer.close()
            my_str = "$file:$"
            my_str_as_bytes = my_str.encode(encoding='utf-8')
            self.request.sendall(my_str_as_bytes)
        else:
            #print("my_str_as_bytes: ", my_str_as_bytes, type(my_str_as_bytes))
            self.request.sendall(my_str_as_bytes)

if __name__ == "__main__":
    HOST, PORT = socket.gethostname(), 11958

    server = socketserver.TCPServer((HOST, PORT), xlcalcnetTCPHandler)
    server.serve_forever()
    
    