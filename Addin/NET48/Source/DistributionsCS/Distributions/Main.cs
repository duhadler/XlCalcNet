using System;
using ArbPrecNet;

namespace Distributions
{




    static class Program
    {




        public static void DemoBasicDist()
        {
            DistCornish.CornishEdgeworthDemo();
            DistCornish.InversCornishEdgeworthDemo();
            DistCornishArb.Demo_Saddlepoint_By_Cumulants();
            DistCornishArb.CornishEdgeworthDemoArb();
            DistCornish.DemoShanks();

            DistMain.BetaDisdemo();
            DistXArb.Demo_arb_ibeta();
            DistXArb.demoNemes();
            DistMain.DemoCdis();
            DistMain.Demo_gamma_p();
            DistXArb.DemoGamma_q();
            DistXArb.DemoGamma_Arb_p();
            DistXArb.demoParis();

            DistX.demoNdisx();
            DistX.demoCdisx();
            DistX.demoFdisx();
            DistX.demoTdisx();
            DistX.demoBetadisx();

            DistXArb.demoNdisxArb();
            DistXArb.demoCdisxArb();
            DistXArb.demoFdisxArb();
            DistXArb.demoTdisxArb();
            DistXArb.demoBetadisxArb();

            DistX.demo_ibeta_inv();
            DistX.demo_ibetac_inv();
            DistX.demoGamma_q_inv();
            DistX.demoGamma_p_inv();

            DistXArb.demo_ibeta_invArb();
            DistXArb.demo_ibetac_invArb();
            DistXArb.demoGamma_p_invArb();
            DistXArb.demoGamma_q_invArb();

            DemoPearsonDouble.DemoPearsonDoubleProcs();

            DistFromBoost.DemoAcbIntegrationChiSquare();
            DistFromBoost.DemoAcbIntegrationGammaStar();
            DistRoy.DemoArbInt();
            Module1.DE_Int_Main();

            DistFromBoost.DemoDistFromBoost();
        }



        public static void DemoMCP()
        {
            DistMCP.DemoModulus();
            DistMCP.DemoDunnett();
            DistMCP.DemoRange();

            DistMCP2.demoMCP2();
            DistMCP2.DemoMCP3();

            DistMCPArb.DemoMCPArb();
        }



        public static void DemoMultivariate()
        {

            DistRoy.RoyDemo();
            DistRoy.RoyDemoAnderson();

            DistWilks.DemoUdisx();
            DistBoxDavis.Udisdemo();
            DistBoxDavisArb.UdisdemoArb();
            DistBoxDavis.Udis2demo();
            DistBoxDavis.Udis3demo();
            DistBoxDavis.NewTestWilksU();
            DistBoxDavisArb.NewTestWilksUArb();

            DistBoxDavis.NewTestBartlett();
            DistBoxDavis.NewTestR0KSetsDis();
            DistBoxDavis.NewTestMauchley();
            DistBoxDavis.NewTestR0DisX();
            DistBoxDavis.NewTestLvcm0DisX();
            DistBoxDavis.NewTestLvcmDisX();
            DistBoxDavis.NewTestLvcDisX();
            DistBoxDavis.NewEqualDistributions();
            DistBoxDavis.EqualDistributions();
            DistBoxDavis.NewBartlett();
            DistBoxDavis.Bartlettdemo();
            DistBoxDavis.Mauchlydemo();
            DistBoxDavis.Lvcdemo();
            DistBoxDavis.Lvcmdemo();

            DistPillaiHotelling.DemoOmega_V();
            DistPillaiHotelling.DemoOmega_T();
            DistPillaiHotelling.DemoCalcHotellingArb();
            DistPillaiHotelling.DemoCalcPillaiArb();

            DistMCPArb.Demo_g_betaflintproduct_GL();
            DistMCPArb.Demo_g_chisquared_GL();

        }



        public static void DemoNoncentral()
        {

            DistNArb.aflint_DemoNoncentral();
            DistN.DemoNoncentralDouble();

            DistWilks.TestHypergeometric1F1Matrix();
            DistWilks.TestHypergeometric2F1Matrix();
            DistWilks.DemoGLMPower();

            DistN.TestNonCentralChi2();
            DistFromBoost.DemoNoncentralCDF();

            DistN.DemoQuantileR2();
            DistN.DemoNoncentralityR2();
            DistN.DemoSampleSizeR2();

            DistN.demo_tdisn_samplesize();
            DistN.DemoRhoExplicit();
            DistN.DemoQuantileNoncentralChisquare();
            DistN.Demo_ChiSquare_Lambda();
            DistN.demo_tdisn_delta();
            DistN.demo_tdisnx();
            DistN.DemoMarcumQ();
            DistN.DemoDoublyFdisn();

            DistFromBoost.DemoNoncentralCDF();
            DistFromBoost.DemoNoncentralPdf();

        }



        public static void DemoNonparametric()
        {

            // Demo_Wilcoxon_CDF_SPA()   ' aflint.cosh yields nan
            // Demo_Wilcoxon_CDF_SPA_By_Cumulants()
            // Demo_Wilcoxon_CGF_By_Cumulants()
            // WilcoxonCornishDemoArb()
            // WilcoxonInversCornishDemoArb()
            // DemoWilcoxonCalcArb()

            // Demo_MannWhitney_Saddlepoint_By_CGF()
            // Demo_MannWhitney_Saddlepoint_By_Cumulants()
            // Demo_MannWhitney_CDF_SPA_By_Cumulants()
            // Demo_MannWhitney_CDF_SPA()   ' !!! seems to work
            // Demo_MannWhitney_CGF()
            // Demo_MannWhitney_CGF_By_Cumulants()
            // MannWhitneyInversCornishDemoArb()
            // MannWhitneyCornishDemoArb()  ' calculates inverse function
            //DistCornishArb.DemoMannWhitneyCalcArb();   // this is the exact PMF

            // Demo_Kendall_Saddlepoint_By_Cumulants()
            // Demo_Kendall_CGF_By_Cumulants()
            // Demo_Kendall_CDF_SPA()
            // KendallInversCornishEdgeworthDemo()
            // KendallCornishDemoArb()
            // KendallInversCornishDemoArb()
            // DemoKendallCalcArb()

            // TerpstaCornishDemoArb()
            // TerpstaInversCornishDemoArb2()
            // TerpstaCornishDemoArb()
            // DemoTerpstaCalcArb()

            // PageCornishDemoArb()
            // DemoPageCalcArb()
            // PageInversCornishDemoArb()
            // DemoQuadePageCalcArb()
            // DemoSignCalcArb()

            //DistCornish.ListNullCDFbyCumDemo();  // working on it
            PermMilton.DemoMilton();
            //PermKruskal.Kruskaldemo2();
            //PermFriedman.DemoFriedman();

            // LehmannDemoRecursive()

        }



        public static void Main()
        {

            ArbPrec.SetDps(15);
            // DemoBasicDist()
            // DemoMCP()
            // DemoMultivariate()
            // DemoNoncentral()
            DemoNonparametric();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }


    }
}