from string import ascii_letters
import numpy as np
import pandas as pd
import seaborn as sns
import matplotlib.pyplot as plt



outpath = r"C:\Users\dietrichhadler\Documents\Python310\Lib\site-packages\xlfunlab\Test"




# See also: https://seaborn.pydata.org/examples/hexbin_marginals.html
def hexbin():
    fig, ax = plt.subplots(figsize=(6, 6))

    sns.set_theme(style="ticks")
    rs = np.random.RandomState(11)
    x = rs.gamma(2, size=1000)
    y = -.5 * x + rs.normal(size=1000)
    sns.jointplot(x=x, y=y, kind="hex", color="#4CB391")
    #plt.show()
    plt.savefig(outpath + r'\hexbin.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\hexbin.pdf', bbox_inches='tight')




# See also: https://seaborn.pydata.org/examples/joint_kde.html
def joint_kde():
    sns.set_theme(style="ticks")
    # Load the penguins dataset
    penguins = sns.load_dataset("penguins")
    # Show the joint distribution using kernel density estimation
    g = sns.jointplot(
        data=penguins,
        x="bill_length_mm", y="bill_depth_mm", hue="species",
        kind="kde",
    )
    #plt.show()
    plt.savefig(outpath + r'\joint_kde.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\joint_kde.pdf', bbox_inches='tight')






# See also: https://seaborn.pydata.org/examples/marginal_ticks.html
def marginal_ticks():
    sns.set_theme(style="white", color_codes=True)
    mpg = sns.load_dataset("mpg")

    # Use JointGrid directly to draw a custom plot
    g = sns.JointGrid(data=mpg, x="mpg", y="acceleration", space=0, ratio=17)
    g.plot_joint(sns.scatterplot, size=mpg["horsepower"], sizes=(30, 120),
                 color="g", alpha=.6, legend=False)
    g.plot_marginals(sns.rugplot, height=1, color="g", alpha=.6)
    #plt.show()
    plt.savefig(outpath + r'\marginal_ticks.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\marginal_ticks.pdf', bbox_inches='tight')





# See also: https://seaborn.pydata.org/examples/regression_marginals.html
def regression_marginals():
    sns.set_theme(style="darkgrid")

    tips = sns.load_dataset("tips")
    g = sns.jointplot(x="total_bill", y="tip", data=tips,
                      kind="reg", truncate=False,
                      xlim=(0, 60), ylim=(0, 12),
                      color="m", height=7)
    #plt.show()
    plt.savefig(outpath + r'\regression_marginals.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\regression_marginals.pdf', bbox_inches='tight')










# See also: https://seaborn.pydata.org/examples/pair_grid_with_kde.html
def pair_grid_with_kde():
    sns.set_theme(style="white")
    df = sns.load_dataset("penguins")
    g = sns.PairGrid(df, diag_sharey=False)
    g.map_upper(sns.scatterplot, s=15)
    g.map_lower(sns.kdeplot)
    g.map_diag(sns.kdeplot, lw=2)
    #plt.show()
    plt.savefig(outpath + r'\pair_grid_with_kde.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\pair_grid_with_kde.pdf', bbox_inches='tight')



# See also: https://seaborn.pydata.org/examples/scatterplot_matrix.html
def scatterplot_matrix():
    sns.set_theme(style="ticks")
    df = sns.load_dataset("penguins")
    sns.pairplot(df, hue="species")
    #plt.show()
    plt.savefig(outpath + r'\scatterplot_matrix.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\scatterplot_matrix.pdf', bbox_inches='tight')









# See also: https://seaborn.pydata.org/examples/many_pairwise_correlations.html
def many_pairwise_correlations():
    sns.set_theme(style="white")
    # Generate a large random dataset
    rs = np.random.RandomState(33)
    d = pd.DataFrame(data=rs.normal(size=(100, 26)),
                     columns=list(ascii_letters[26:]))

    # Compute the correlation matrix
    corr = d.corr()

    # Generate a mask for the upper triangle
    mask = np.triu(np.ones_like(corr, dtype=bool))

    # Set up the matplotlib figure
    f, ax = plt.subplots(figsize=(11, 9))

    # Generate a custom diverging colormap
    cmap = sns.diverging_palette(230, 20, as_cmap=True)

    # Draw the heatmap with the mask and correct aspect ratio
    sns.heatmap(corr, mask=mask, cmap=cmap, vmax=.3, center=0,
                square=True, linewidths=.5, cbar_kws={"shrink": .5})
    #plt.show()
    plt.savefig(outpath + r'\many_pairwise_correlations.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\many_pairwise_correlations.pdf', bbox_inches='tight')



# See also: https://seaborn.pydata.org/examples/structured_heatmap.html
def structured_heatmap():
    sns.set_theme()

    # Load the brain networks example dataset
    df = sns.load_dataset("brain_networks", header=[0, 1, 2], index_col=0)

    # Select a subset of the networks
    used_networks = [1, 5, 6, 7, 8, 12, 13, 17]
    used_columns = (df.columns.get_level_values("network")
                              .astype(int)
                              .isin(used_networks))
    df = df.loc[:, used_columns]

    # Create a categorical palette to identify the networks
    network_pal = sns.husl_palette(8, s=.45)
    network_lut = dict(zip(map(str, used_networks), network_pal))

    # Convert the palette to vectors that will be drawn on the side of the matrix
    networks = df.columns.get_level_values("network")
    network_colors = pd.Series(networks, index=df.columns).map(network_lut)

    # Draw the full plot
    g = sns.clustermap(df.corr(), center=0, cmap="vlag",
                       row_colors=network_colors, col_colors=network_colors,
                       dendrogram_ratio=(.1, .2),
                       cbar_pos=(.02, .32, .03, .2),
                       linewidths=.75, figsize=(12, 13))
    g.ax_row_dendrogram.remove()
    #plt.show()
    plt.savefig(outpath + r'\structured_heatmap.svg', bbox_inches='tight')
    plt.savefig(outpath + r'\structured_heatmap.pdf', bbox_inches='tight')



#hexbin()
#marginal_ticks()

#regression_marginals()
#joint_kde()


#pair_grid_with_kde()
#scatterplot_matrix()

#many_pairwise_correlations()
structured_heatmap()














