Imports System
Imports System.Numerics
Imports System.Diagnostics
Imports FixedPrecNet
Imports ArbPrecNet




Module Program




    Sub DemoBasicDist()
        CornishEdgeworthDemo()
        InversCornishEdgeworthDemo()
        Demo_Saddlepoint_By_Cumulants()
        CornishEdgeworthDemoArb()
        DemoShanks()

        BetaDisdemo()
        Demo_arb_ibeta()
        demoNemes()
        DemoCdis()
        Demo_gamma_p()
        DemoGamma_q()
        DemoGamma_Arb_p()
        demoParis()

        demoNdisx()
        demoCdisx()
        demoFdisx()
        demoTdisx()
        demoBetadisx()

        demoNdisxArb()
        demoCdisxArb()
        demoFdisxArb()
        demoTdisxArb()
        demoBetadisxArb()

        demo_ibeta_inv()
        demo_ibetac_inv()
        demoGamma_q_inv()
        demoGamma_p_inv()

        demo_ibeta_invArb()
        demo_ibetac_invArb()
        demoGamma_p_invArb()
        demoGamma_q_invArb()

        DemoPearsonDoubleProcs()

        DemoAcbIntegrationChiSquare()
        DemoAcbIntegrationGammaStar()
        DemoArbInt()
        DE_Int_Main()

        DemoDistFromBoost()
    End Sub



    Sub DemoMCP()
        DemoModulus()
        DemoDunnett()
        DemoRange()

        demoMCP2()
        DemoMCP3()

        DemoMCPArb()
    End Sub



    Sub DemoMultivariate()

        RoyDemo()
        RoyDemoAnderson()

        DemoUdisx()
        Udisdemo()
        UdisdemoArb()
        Udis2demo()
        Udis3demo()
        NewTestWilksU()
        NewTestWilksUArb()

        NewTestBartlett()
        NewTestR0KSetsDis()
        NewTestMauchley()
        NewTestR0DisX()
        NewTestLvcm0DisX()
        NewTestLvcmDisX()
        NewTestLvcDisX()
        NewEqualDistributions()
        EqualDistributions()
        NewBartlett()
        Bartlettdemo()
        Mauchlydemo()
        Lvcdemo()
        Lvcmdemo()

        DemoOmega_V()
        DemoOmega_T()
        DemoCalcHotellingArb()
        DemoCalcPillaiArb()

        Demo_g_betaflintproduct_GL()
        Demo_g_chisquared_GL()

    End Sub



    Sub DemoNoncentral()

        aflint_DemoNoncentral()
        DemoNoncentralDouble()

        TestHypergeometric1F1Matrix()
        TestHypergeometric2F1Matrix()
        DemoGLMPower()

        TestNonCentralChi2()
        DemoNoncentralCDF()

        DemoQuantileR2()
        DemoNoncentralityR2()
        DemoSampleSizeR2()

        demo_tdisn_samplesize()
        DemoRhoExplicit()
        DemoQuantileNoncentralChisquare()
        Demo_ChiSquare_Lambda()
        demo_tdisn_delta()
        demo_tdisnx()
        DemoMarcumQ()
        DemoDoublyFdisn()

        DemoNoncentralCDF()
        DemoNoncentralPdf()

    End Sub



    Sub DemoNonparametric()

        'Demo_Wilcoxon_CDF_SPA()   ' aflint.cosh yields nan
        'Demo_Wilcoxon_CDF_SPA_By_Cumulants()
        'Demo_Wilcoxon_CGF_By_Cumulants()
        'WilcoxonCornishDemoArb()
        'WilcoxonInversCornishDemoArb()
        'DemoWilcoxonCalcArb()

        'Demo_MannWhitney_Saddlepoint_By_CGF()
        'Demo_MannWhitney_Saddlepoint_By_Cumulants()
        'Demo_MannWhitney_CDF_SPA_By_Cumulants()
        'Demo_MannWhitney_CDF_SPA()   ' !!! seems to work
        'Demo_MannWhitney_CGF()
        'Demo_MannWhitney_CGF_By_Cumulants()
        'MannWhitneyInversCornishDemoArb()
        'MannWhitneyCornishDemoArb()  ' calculates inverse function
        DemoMannWhitneyCalcArb()   ' this is the exact PMF

        'Demo_Kendall_Saddlepoint_By_Cumulants()
        'Demo_Kendall_CGF_By_Cumulants()
        'Demo_Kendall_CDF_SPA()
        'KendallInversCornishEdgeworthDemo()
        'KendallCornishDemoArb()
        'KendallInversCornishDemoArb()
        'DemoKendallCalcArb()

        'TerpstaCornishDemoArb()
        'TerpstaInversCornishDemoArb2()
        'TerpstaCornishDemoArb()
        'DemoTerpstaCalcArb()

        'PageCornishDemoArb()
        'DemoPageCalcArb()
        'PageInversCornishDemoArb()
        'DemoQuadePageCalcArb()
        'DemoSignCalcArb()

        ListNullCDFbyCumDemo()  ' working on it
        'DemoMilton()
        'Kruskaldemo2()
        'DemoFriedman()

        'LehmannDemoRecursive()

    End Sub



    Sub Main()

        ArbPrec.SetDps(15)
        'DemoBasicDist()
        'DemoMCP()
        'DemoMultivariate()
        'DemoNoncentral()
        DemoNonparametric()

        Console.Write("Press any key to continue . . . ")
        Console.ReadKey(True)
    End Sub


End Module
