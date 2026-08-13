# -*- coding: utf-8 -*-
"""
@author: DH
"""


from xlcalcnet.dist_base import ctx_rv_discrete


# %% 30 Discrete (non-lattice) distributions related to rank tests


class ctx_friedman(ctx_rv_discrete):


    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"


class ctx_kruskal_wallis(ctx_rv_discrete):


    def __init__(self, ctx, n, lambda1_):
        self.set_ctx(ctx)
        self.n = ctx.t(n)

        self.set_rangeleft(0)
        self.set_rangeright(ctx.inf)

        self.set_supportleft(0)
        self.set_supportright(ctx.inf)

    def pdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def cdf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def sf(self, x):
        ctx = self.ctx
        x = ctx.t(x)
        return "Todo"

    def qtf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def isf(self, q):
        ctx = self.ctx
        q = ctx.t(q)
        return "Todo"

    def c_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def m_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def k_x(self, t):
        ctx = self.ctx
        t = ctx.t(t)
        return "Todo"

    def saddleppoint(self, x):
        return "Todo"

    def moments(self, k):
        k = int(k)
        return "Todo"

    def cumulants(self, k):  
        k = int(k)
        return "Todo"




class ctxFriedman(object):

    #  Cochran 𝑆 distribution (under 𝐻0), pmf vector

    #  Friedman 𝑆 distribution (under 𝐻0), pmf vector

    #  Quade 𝑆 distribution (under 𝐻0), pmf vector

    def friedman_s_pmf_vector(self, ctx, GetWhat, sum2, n, Quade, Mode, Mode2):

        vlimit = 1000000
        vlimit = 10000
        zfak = [0.0]*(vlimit)
        vfak = [0.0]*(vlimit)
        rows = n + 1
        cols = sum2 + 1
        x = [[0 for col in range(cols)] for row in range(rows)]
        cols = vlimit + 1
        rows = sum2 + 1
        zv = [[0 for col in range(cols)] for row in range(rows)]
        cols = vlimit + 1
        rows = sum2 + 1
        v = [[0 for col in range(cols)] for row in range(rows)]
        w = [0]*(sum2 + 1)
        zz = [0]*(sum2 + 1)
        b = [0]*(sum2 + 1)
        y = [0]*(sum2 + 1)
        z = [0]*(sum2 + 1)
        diff = [0]*(2 * (sum2 + 1) + 1)

        show = True
        for i in range(1, n+1):
            for j in range(1, sum2+1):
                if Quade == 2:
                    x[i][j] = 2 * j * i
                else:
                    x[i][j] = 2 * j
        asymend = 0

        if show:
            print("Listing des Datensatzes")
            print("-----------------------")
            for i in range(1, n+1):
                sline = str(i) + ".Block: "
                for j in range(1, sum2+1):
                    sline = sline + str(x[i][j]) + "  "
                print(sline)

        sdiv2 = sum2 // 2
        sum3 = sum2 + 1
        if Mode >= 2:
            sumanz = 1
        else:
            sumanz = sum2 - 1
        fit = 1
        h = sumanz
        permanz = 1
        Last = 0
        Varianz = 0

        for k in range(1, sum2+1):
            zv[k][1] = 0
            y[k] = 0
            permanz = permanz * k
        cols = permanz + 1
        rows = sum2 + 1
        perm = [[0 for col in range(cols)] for row in range(rows)]
        pfak = [0]*(permanz + 1)

        vlength = 1
        rsum = 0
        # zfak[1] = 1.0E-300 #'   (*permanz;*)
        zfak[1] = 1  # '   (*permanz;*)
        vfak[1] = 0

        for it in range(1, n+1):
            vneuend = 1
            lastrsum = rsum
            first = True
            notsame = False
            mean = 0

            for k in range(1, sum2+1):
                mean = mean + fit * x[it][k]
            mean = mean // sum2
            for k in range(1, sum2+1):
                yk = fit * x[it][k] - mean
                rsum = rsum + yk
                Varianz = Varianz + (yk * yk)
                if yk != y[k]:
                    notsame = True
                y[k] = yk

    #            '(************************************
    #            ' *  permutations of the ith block  *
    #            ' ************************************)

            if notsame:
                permneu = 0
                for j in range(permanz, 1-1, -1):
                    z[1] = 0
                    nr = j
                    pn = permanz
                    for k in range(1, sum2+1):
                        b[k] = k
                    for k in range(sum2, 1-1, -1):
                        pn = pn // k
                        s2 = (nr - 1) // pn
                        nr = nr - pn * s2
                        s2 = s2 + 1
                        if Mode == 1:
                            z[k] = y[b[s2]]
                        if Mode == 2:
                            z[1] = z[1] - (2 * k - sum3) * y[b[s2]]
                        for k1 in range(s2, k):
                            b[k1] = b[k1 + 1]
                    i = 1
                    notfound = True
                    while (notfound and (i <= permneu)):
                        k = 1
                        while ((perm[k][i] == z[k]) and (k < sum2)):
                            k = k + 1
                        if k == sum2:
                            notfound = False
                        else:
                            i = i + 1
                    if notfound:
                        permneu = permneu + 1
                        for k in range(1, sum2+1):
                            perm[k][i] = z[k]
                        pfak[i] = 1
                    else:
                        pfak[i] = pfak[i] + 1

    #            '(**************************************
    #            ' *   Calculate rank sums        *
    #            ' **************************************)

            k2 = 0
            for i in range(1, vlength+1):
                zfaki1 = zfak[i]
                tsum = 0
                for k in range(1, h+1):
                    k2 = k2 + 1
                    zz[k] = zv[k][i]
                    tsum = tsum + zz[k]
                zz[sum2] = lastrsum - tsum

                for j in range(1, permneu+1):
                    zfaki = zfaki1 * pfak[j]
                    if Mode > 1:
                        w[1] = zz[1] + perm[1][j]
                    else:
                        for k in range(1, sum2+1):
                            w[k] = zz[k] + perm[k][j]
                        while True:
                            sortiert = True
                            for k in range(1, sumanz+1):
                                k1 = k + 1
                                if w[k] > w[k1]:
                                    w1 = w[k]
                                    w[k] = w[k1]
                                    w[k1] = w1
                                    sortiert = False
                            if sortiert:
                                break

                        if it >= asymend:
                            k = 0
                            k1 = sum3
                            while True:
                                k = k + 1
                                k1 = k1 - 1
                                if ((-w[k] != w[k1]) or (k == sdiv2)):
                                    break

                            if -w[k] < w[k1]:
                                for k in range(1, sum2+1):
                                    w[k] = -w[k]
                                k1 = sum2
                                for k in range(1, sdiv2+1):
                                    w1 = w[k]
                                    w[k] = w[k1]
                                    w[k1] = w1

                    if first:
                        first = False
                        for k in range(1, h+1):
                            v[k][1] = w[k]
                        vfak[1] = zfaki
                    else:
                        l = 1
                        r = vneuend
                        while True:
                            m = (l + r + 1) // 2
                            k = 0
                            while True:
                                k = k + 1
                                vref = v[k][m]
                                EQ = (vref == w[k])
                                if (not ((k < h) and EQ)):
                                    break

                            LE = (vref <= w[k])
                            if LE:
                                l = m
                            else:
                                r = m - 1
                            if l == r:
                                break

                        k = 1
                        while (v[k][l] == w[k]) and (k <= h):
                            k = k + 1
                        if k == (h + 1):
                            vfak[l] = vfak[l] + zfaki
                        else:
                            vneuend = vneuend + 1
                            l = l + 1
                            if vneuend > vlimit:
                                print("Not enough memory")
                                return None

                            if vneuend != l:
                                for i1 in range(vneuend, l-1, -1):
                                    i2 = i1 + 1
                                    vfak[i2] = vfak[i1]
                                    for k in range(1, h+1):
                                        v[k][i2] = v[k][i1]
                            vfak[l] = zfaki

                            for k in range(1, h+1):
                                v[k][l] = w[k]

            ve = vneuend
            for i in range(0, ve+1):
                zfak[i] = vfak[i]
                for k in range(1, h+1):
                    zv[k][i] = v[k][i]
            vlength = vneuend
            Last = vneuend

            # '{    CalcTestDis(mode2,sum2-1,vlength);}
        s = 0

        rv = ctx.matrix(vlimit + 1, 1)
        rvfak = ctx.matrix(vlimit + 1, 1)

        print("Start Sorting")

        if Mode2 >= 7:
            return None
        slength = 1
        first = True
        k2 = 0

        Ranks = ctx.matrix(vlength - 1+1, h+1)
        for i in range(1, vlength+1):
            zfaki = zfak[i]
            print("i:", i, "zfaki", zfaki)

            sanz = 1
            tsum = 0
            for k in range(1, h+1):
                k2 = k2 + 1
                w[k] = zv[k][i]
                tsum = tsum + w[k]
                Ranks[i - 1, k - 1] = int(zv[k][i]) // 2
            w[sum2] = rsum - tsum
            if Mode2 == 1:
                s = 0
                for k in range(1, sum2+1):
                    stemp = w[k]
                    stemp = stemp * stemp
                    s = s + stemp

            if Mode2 == 6:
                s = w(1)
                for j in range(2, sum2+1):
                    s = s + j * w[j]

            if Mode2 == 2:
                s = w[sum2] - w[1]

            if ((Mode2 == 3) or (Mode2 == 4)):
                if Mode2 == 3:
                    dloop = 2
                else:
                    dloop = 1
                k3 = 1
                for j in range(1, dloop+1):
                    for k in range(1, sum2):
                        w[k] = -w[k]
                    for k in range(1, sum2+1):
                        dun1 = -30000
                        for k1 in range(1, sum2+1):
                            if k1 != k:
                                dun = w[k] - w[k1]
                                if Mode2 == 4:
                                    dun = ctx.fabs(dun)
                                if dun > dun1:
                                    dun1 = dun
                        diff[k3] = dun1
                        k3 = k3 + 1
                sanz = dloop * sum2

            if Mode2 == 5:
                s = -w[1]
                if s < w[sum2]:
                    s = w[sum2]

            while sanz > 0:
                if (Mode2 == 3) or (Mode2 == 4):
                    s = diff[sanz]
                if first:
                    first = False
                    rv[1] = s
                    rvfak[1] = zfaki
                else:
                    l = 1
                    r = slength
                    while True:
                        m = (l + r + 1) // 2    # ' (* M:=(L+r+1) div 2;*)
                        if rv[m] >= s:
                            l = m
                        else:
                            r = m - 1
                        if l == r:
                            break

                    if rv[l] == s:
                        rvfak[l] = rvfak[l] + zfaki
                    else:
                        slength = (slength + 1)
                        l = l + 1
                        for i1 in range(slength, l-1, -1):
                            i2 = i1 + 1
                            rv[i2] = rv[i1]
                            rvfak[i2] = rvfak[i1]
                        rvfak[l] = zfaki
                        rv[l] = s
                sanz = sanz - 1

        #nnr = 1.0E-300
        nnr = 1
        if ((Mode2 == 3) or (Mode2 == 4)):
            nnr = nnr * sum2 * dloop
        for i in range(1, n+1):
            nnr = nnr * permanz
        pcum = 0
        Output = ctx.matrix(slength - 1+1, 3+1)
        print("W,            pmf,               CDF,             Approx to CDF")

        for i in range(1, slength+1):
            p1 = rvfak[i] / nnr
            pcum = pcum + p1
            if Mode2 == 1:
                Chi2 = rv[i] / Varianz * h
            else:
                Chi2 = rv[i] / 2
            Output[i - 1, 0] = Chi2 / 2
            Output[i - 1, 1] = p1
            Output[i - 1, 2] = pcum
            Output[i - 1, 3] = 1 - ctx.chi2_cdf(Chi2, h)
            print("W:", Output[i - 1, 0], "pmf:", Output[i - 1, 1],
                  "CDF:", Output[i - 1, 2], "cdis:", Output[i - 1, 3])

        print("Anzahl der Permutationen: ", 1 * nnr)
        return Output


class ctxKruskal(object):

    NewDataX = []
    OldDataX = []
    NewDataR = []
    OldDataR = []
    NewDataSize = []
    OldDataSize = []
    NewDataStart = []
    OldDataStart = []
    m = 0
    MaxTLength = 0

    def initdata(self, mm, MaxVLength, linear):
        self.MaxTLength = 8192
        if linear:
            self.m = 0
        else:
            self.m = mm
        self.OldDataSize = [0 for row in range(self.MaxTLength+2)]
        self.NewDataSize = [0 for row in range(self.MaxTLength+2)]
        self.OldDataStart = [0 for row in range(self.MaxTLength+2)]
        self.NewDataStart = [0 for row in range(self.MaxTLength+2)]
        self.OldDataX = [0 for row in range(self.MaxTLength+2)]
        self.NewDataX = [0 for row in range(self.MaxTLength+2)]
        rows = self.m+1
        cols = self.MaxTLength
        self.OldDataR = [[0 for col in range(cols)] for row in range(rows)]
        rows = self.m+1
        cols = self.MaxTLength
        self.NewDataR = [[0 for col in range(cols)] for row in range(rows)]
        self.OldDataSize[0] = 0
        self.OldDataStart[0] = 0
        self.OldDataX[0] = 1
        for j in range(0, self.m+1):
            self.OldDataR[j][0] = 0

    def DoneData(self):
        self.NewDataSize = []
        self.OldDataSize = []
        self.NewDataStart = []
        self.OldDataStart = []
        self.NewDataX = []
        self.OldDataX = []
        self.NewDataR = []
        self.OldDataR = []

    def BuildNew(self, NextRank, NewDest, CurNumCount, CurNum, AddPos, n, v, linear, score):
        rows = CurNumCount+1
        cols = self.m+1
        w = [[0 for col in range(cols)] for row in range(rows)]
        z = [0 for row in range(CurNumCount+1)]
        Min = [0 for row in range(self.m+1)]
        LocalPos = [0 for row in range(CurNumCount+1)]
        NV = [0 for row in range(CurNumCount+1)]
        nvSum = 0
        for j in range(0, CurNumCount+1):
            NV[j] = n[j] * v[j]
            nvSum = nvSum + NV[j]
        for j in range(0, CurNumCount+1):
            NV[j] = NV[j] / nvSum
        if NewDest == 0:
            self.NewDataStart[NewDest] = 0
        else:
            self.NewDataStart[NewDest] = self.NewDataStart[NewDest -
                                                           1] + self.NewDataSize[NewDest - 1] + 1
        NND = self.NewDataStart[NewDest]
        NewCount = 0
        for j in range(0, CurNumCount+1):
            LocalPos[j] = 0
            z[j] = self.OldDataX[self.OldDataStart[CurNum[j]]]
            for k in range(0, self.m+1):
                w[j][k] = self.OldDataR[k][self.OldDataStart[CurNum[j]]]
                if linear:
                    w[j][k] = w[j][k] + NextRank * score[AddPos[j]]
                else:
                    if k == AddPos[j]:
                        w[j][k] = w[j][k] + NextRank
            if j == 0:
                for k in range(0, self.m+1):
                    Min[k] = w[j][k]
            k4 = -1
            while True:
                k4 = k4 + 1
                if not ((k4 < (self.m - 1)) and (Min[k4] == w[j][k4])):
                    break
            if (w[j][k4] < Min[k4]):
                for k in range(0, self.m+1):
                    Min[k] = w[j][k]
        while CurNumCount >= 0:
            for j in range(0, CurNumCount+1):
                k4 = -1
                while True:
                    k4 = k4 + 1
                    if not ((k4 < (self.m - 1)) and (Min[k4] == w[j][k4])):
                        break
                if (w[j][k4] < Min[k4]):
                    for k in range(0, self.m+1):
                        Min[k] = w[j][k]
            NewZ = 0
            for j in range(0, CurNumCount+1):
                k4 = -1
                while True:
                    k4 = k4 + 1
                    if not ((k4 < (self.m - 1)) and (Min[k4] == w[j][k4])):
                        break
                if (Min[k4] == w[j][k4]):
                    NewZ = NewZ + NV[j] * z[j]
                    if LocalPos[j] < self.OldDataSize[CurNum[j]]:
                        LocalPos[j] = LocalPos[j] + 1
                        j1 = self.OldDataStart[CurNum[j]] + LocalPos[j]
                        z[j] = self.OldDataX[j1]
                        for k in range(0, self.m+1):
                            w[j][k] = self.OldDataR[k][j1]
                        if linear:
                            w[j][self.m] = w[j][self.m] + \
                                NextRank * score[AddPos[j]]
                        else:
                            w[j][AddPos[j]] = w[j][AddPos[j]] + NextRank
                    else:
                        for k in range(j + 1, CurNumCount+1):
                            CurNum[k - 1] = CurNum[k]
                            LocalPos[k - 1] = LocalPos[k]
                            AddPos[k - 1] = AddPos[k]
                            NV[k - 1] = NV[k]
                            score[k - 1] = score[k]
                        CurNumCount = CurNumCount - 1
            if NND + NewCount > self.MaxTLength - 1:
                self.MaxTLength = 2 * self.MaxTLength
                for i in range(self.MaxTLength):
                    self.OldDataX.append(0)
                for i in range(self.MaxTLength):
                    self.NewDataX.append(0)
                for i in range(0, self.m+1):
                    for j in range(0, self.MaxTLength):
                        self.OldDataR[i].append(0)
                for i in range(0, self.m+1):
                    for j in range(0, self.MaxTLength):
                        self.NewDataR[i].append(0)
            for k in range(0, self.m+1):
                self.NewDataR[k][NND + NewCount] = Min[k]
            self.NewDataX[NND + NewCount] = NewZ
            for k in range(0, self.m+1):
                Min[k] = w[0][k]
            NewCount = NewCount + 1
        self.NewDataSize[NewDest] = NewCount - 1

    def GetFinalVector(self):
        k = 0
        FinalSize = self.OldDataSize[k]
        ok = self.OldDataStart[k]
        FinalX = [0 for row in range(FinalSize+1)]
        rows = self.m+1
        cols = FinalSize + 1
        FinalR = [[0 for col in range(cols)] for row in range(rows)]
        for i in range(0, self.OldDataSize[k]+1):
            FinalX[i] = self.OldDataX[ok + i]
            for j in range(0, self.m+1):
                FinalR[j][i] = self.OldDataR[j][ok + i]
        return FinalSize, FinalX, FinalR

    def ShowOldVector(self, k):
        ok = self.OldDataStart(k)
        print("---Old Vector------Size: " + str(self.OldDataSize[k]))
        s2 = ""
        for i in range(0, self.OldDataSize[k]+1):
            s2 = str(i) + ".  " + str(self.OldDataX[ok + i]) + ": "
            for j in range(0, self.m+1):
                s2 = s2 + str(self.OldDataR[j][ok + i])
                if j < self.m:
                    s2 = s2 + ","
            print(s2)

    def ShowNewVector(self, k):
        nk = self.NewDataStart(k)
        print("---New Vector------Size: " + str(self.NewDataSize[k]))
        s2 = ""
        for i in range(0, self.NewDataSize[k]+1):
            s2 = str(i) + ".  " + str(self.NewDataX(nk + i)) + ": "
            for j in range(0, self.m+1):
                s2 = s2 + str(self.NewDataR(j, nk + i))
                if j < self.m:
                    s2 = s2 + ","
            print(s2)
        print("---End New Vector-----")

    def NewToOld(self, MaxVLength):
        print("    NewToOld: ", MaxVLength)
        for k in range(0, MaxVLength+1):
            nk = self.NewDataStart[k]
            self.OldDataSize[k] = self.NewDataSize[k]
            self.OldDataStart[k] = self.NewDataStart[k]
            for i in range(0, self.NewDataSize[k]+1):
                self.OldDataX[nk + i] = self.NewDataX[nk + i]
                for j in range(0, self.m+1):
                    self.OldDataR[j][nk + i] = self.NewDataR[j][nk + i]

    def CalcRankSums(self, m, ng, n, v, Rank, linear, score):
        calc = True
        showstruc = False
        showvec = False
        h = m - 1
        m1 = m + 1
        zsize = m1 * 6
        ztempsize = m1 * 6
        zlength = [0 for row in range(ng+1)]
        zstart = [0 for row in range(ng+1)]
        AddPos = [0 for row in range(m+1)]
        w = [0 for row in range(m+1)]
        CurNum = [0 for row in range(m+1)]
        t = [0 for row in range(m+1)]
        v4 = [0 for row in range(m+1)]
        n4 = [0 for row in range(m+1)]
        Score4 = [0 for row in range(m+1)]
        ztemp = [0 for row in range(ztempsize+1)]
        z = [0 for row in range(zsize+1)]
        for j in range(0, m+1):
            w[j] = n[j]
        for j in range(0, m+1):
            t[j] = j
        # ' Sorting should be eliminated
        while True:
            sortiert = True
            for k in range(0, m-1+1):
                k1 = k + 1
                if w[k] < w[k1]:
                    w1 = w[k]
                    w[k] = w[k1]
                    w[k1] = w1
                    w1 = t[k]
                    t[k] = t[k1]
                    t[k1] = w1
                    sortiert = False
            if sortiert:
                break
        for j in range(0, m+1):
            n[j] = w[j]
        for k in range(0, m+1):
            z[k] = w[k]
        zlength[ng] = 0
        zstart[ng] = 0
        zmax = 0
        for i in range(ng - 1, -1, -1):
            i1 = i + 1
            zstart[i] = zstart[i1] + (zlength[i1] + 1) * m1
            first = True
            for j in range(0, zlength[i1]+1):
                for k2 in range(0, m+1):
                    if z[zstart[i1] + j * m1 + k2] > 0:
                        for k1 in range(0, m+1):
                            w[k1] = z[zstart[i1] + j * m1 + k1]
                        w[k2] = w[k2] - 1
                        if first:
                            first = False
                            zlength[i] = 0
                            for k in range(0, m+1):
                                ztemp[k] = w[k]
                        else:
                            l = 0
                            r = zlength[i]
                            while True:
                                q = (l + r + 1) // 2
                                k = -1
                                while True:
                                    k = k + 1
                                    vref = ztemp[q * m1 + k]
                                    EQ = (vref == w[k])
                                    if not ((k < h) and EQ):
                                        break
                                LE = (vref <= w[k])
                                if LE:
                                    l = q
                                else:
                                    r = q - 1
                                if (l == r):
                                    break
                            k = 0
                            while (ztemp[l * m1 + k] == w[k]) and (k <= h):
                                k = k + 1
                            if k < m:
                                zlength[i] = zlength[i] + 1
                                if ((zlength[i] + 1) * m1) > (ztempsize):
                                    ztemp2 = ((zlength[i] + 1) * m1)
                                    ztempsize = ztempsize + \
                                        ((zlength[i] + 1) * m1)
                                    for iz2 in range(ztemp2+1):
                                        ztemp.append(0)
                                l = l + 1
                                if zlength[i] != l:
                                    for i2 in range(zlength[i], -1, -1):
                                        for k in range(0, m+1):
                                            ztemp[(i2 + 1) * m1 +
                                                  k] = ztemp[i2 * m1 + k]
                                for k in range(0, m+1):
                                    ztemp[l * m1 + k] = w[k]
            if ((zlength[i] + 1) * m1) > (zsize - zstart[i]):
                ztemp3 = ((zlength[i] + 1) * m1)
                zsize = zsize + ((zlength[i] + 1) * m1)
                for iz3 in range(ztemp3+1):
                    z.append(0)
            for j in range(0, (zlength[i] + 1) * m1 - 1+1):
                z[zstart[i] + j] = ztemp[j]
            if zlength[i] > zmax:
                zmax = zlength[i]
        Last = [0 for row in range(((zmax + 1) * m1)+1)]

        # 'Calculate the Vectors
        if calc:
            self.initdata(m, zmax, linear)
        if (calc and showvec):
            self.ShowOldVector(0)
        for i in range(1, ng+1):
            i1 = i - 1
            print("iteration:", i)
            for j in range(0, ((zlength[i1] + 1) * m1)+1):
                Last[j] = z[zstart[i1] + j]
            Lastj = zlength[i1]
            if showstruc:
                print(str(i) + ". Iteration")
            for j in range(0, zlength[i]+1):
                if showstruc:
                    s2 = ""
                    for k in range(0, m+1):
                        s2 = s2 + str(z[zstart[i] + j * m1 + k])
                    s2 = s2 + "  :"
                    s3 = "   "
                CurNumCount = -1
                for k in range(0, m+1):
                    if z[zstart[i] + j * m1 + k] > 0:
                        for k1 in range(0, m+1):
                            w[k1] = z[zstart[i] + j * m1 + k1]
                        w[k] = w[k] - 1
                        if showstruc:
                            for k1 in range(0, m+1):
                                s2 = s2 + str(w[k1])
                                if k == k1:
                                    s2 = s2 + "+"
                        j2 = -1
                        while True:
                            j2 = j2 + 1
                            k3 = -1
                            while True:
                                k3 = k3 + 1
                                EQ = (w[k3] == Last[j2 * m1 + k3])
                                if not (EQ and (k3 < m)):
                                    break
                            if (EQ or (j2 == Lastj)):
                                break
                        CurrentNumber = j2
                        if not (EQ):
                            CurrentNumber = CurrentNumber + 1
                        CurNumCount = CurNumCount + 1
                        CurNum[CurNumCount] = CurrentNumber
                        AddPos[CurNumCount] = k
                        n4[CurNumCount] = w[k] + 1
                        v4[CurNumCount] = v[k]
                        Score4[CurNumCount] = score[k]
                        if showstruc:
                            s3 = s3 + " [" + str(n4(CurNumCount)) + "; " + str(
                                v4(CurNumCount)) + str(Score4(CurNumCount)) + "], "
                            s2 = s2 + " (" + str(CurNum(CurNumCount)) + \
                                "; " + str(AddPos(CurNumCount)) + ")"
                            s2 = s2 + ", "
                if showstruc:
                    print(s2 + s3)
                if calc:
                    if linear:
                        pass
                    else:
                        self.BuildNew(Rank[i], j, CurNumCount,
                                      CurNum, AddPos, n4, v4, linear, Score4)
                if (calc and showvec):
                    self.ShowNewVector(j)
            if calc:
                self.NewToOld(zlength[i])
        FinalSize, FinalX, FinalR = self.GetFinalVector()
        return FinalSize, FinalX, FinalR
        if calc:
            self.DoneData()

    def CalcStats(self, Mode, m, FinalSize, FinalX, FinalR):
        print("---Final Vector------Size: " + str(FinalSize))
        sum = 0
        for j in range(0, m+1):
            sum = sum + FinalR[j][0]
        mean = sum // (m + 1)
        sum2 = 0
        for j in range(0, m+1):
            d = FinalR[j][0] - mean
            sum2 = sum2 + d * d
        vmax = sum2+2
        print("sum2:", sum2)
        Chi2 = [0 for row in range(vmax+1)]
        for i in range(0, vmax+1):
            Chi2[i] = 0
        for i in range(0, FinalSize+1):
            s2 = str(i) + ".  " + str(FinalX[i]) + ": "
            sum2 = 0
            for j in range(0, m+1):
                d = FinalR[j][i] - mean
                sum2 = sum2 + d * d
                s2 = s2 + str(FinalR[j][i])
                if j < m:
                    s2 = s2 + ","
            Chi2[sum2] = Chi2[sum2] + FinalX[i]
            s2 = s2 + "  ;  " + str(sum2)
        print("Chi2")
        j = 0
        for i in range(0, vmax+1):
            if Chi2[i] > 0:
                j = j + 1
        nlength = j - 1
        x = [0 for row in range(nlength+1)]
        Prob = [0 for row in range(nlength+1)]
        j = 0
        for i in range(0, vmax+1):
            if Chi2[i] > 0:
                Prob[j] = Chi2[i]
                x[j] = i
                j = j + 1
        return nlength, Prob, x

    def Kruskaldemo2(self):
        m = 1  # ' number of groups -1
        linear = False
        n = [0 for row in range(m+1)]
        v = [0 for row in range(m+1)]
        score = [0 for row in range(m+1)]
        for j in range(0, m+1):
            v[j] = j * 0 + 1
        for j in range(0, m+1):
            n[j] = 14
        ng = 0
        for j in range(0, m+1):
            ng = ng + n[j]
        Rank = [0 for row in range(ng+1)]
        for j in range(0, ng+1):
            Rank[j] = j

        FinalSize, FinalX, FinalR = self.CalcRankSums(
            m, ng, n, v, Rank, linear, score)
        Mode = 1
        nlength, Prob, x = self.CalcStats(Mode, m, FinalSize, FinalX, FinalR)
        for i in range(0, nlength+1):
            print("i:", i, "x(i):", x[i], "Prob(i)", Prob[i])


# Kruskal-Wallis 𝐻 distribution (under 𝐻0), pmf vector

    def kruskal_wallis_h_pmf_vector(self, ctx, n):
        # m = 1  #' number of groups -1
        m = len(n)-1
        print("m:", m)
        linear = False
        #n = [0 for row in range(m+1)]
        v = [0 for row in range(m+1)]
        score = [0 for row in range(m+1)]
        for j in range(0, m+1):
            v[j] = j * 0 + 1
#        for j in range(0, m+1):
#            n[j] = 14
        ng = 0
        for j in range(0, m+1):
            ng = ng + n[j]
        Rank = [0 for row in range(ng+1)]
        for j in range(0, ng+1):
            Rank[j] = j

        FinalSize, FinalX, FinalR = self.CalcRankSums(
            m, ng, n, v, Rank, linear, score)
        Mode = 1
        nlength, Prob, x = self.CalcStats(Mode, m, FinalSize, FinalX, FinalR)
        for i in range(0, nlength+1):
            print("i:", i, "x(i):", x[i], "Prob(i)", Prob[i])


