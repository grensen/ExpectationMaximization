# Expectation Maximization from scratch Using C#



Expectation Maximization is used to find the maximum
likelihood of the model parameter when model depends on unobserved 
or latent variables.

Expectation Maximization was proposed 1977 by a paper titled ["Maximum Likelihood from Incomplete Data via the EM Algorithm"](https://www.ece.iastate.edu/~namrata/EE527_Spring08/Dempster77.pdf)
by A. P. Dempster; N. M. Laird; D. B. Rubin.
They pointed out that the method had been proposed in some ways by earlier authors, but with that paper a mighty inference system was born.

There are two core ideas behind the method, the Expectation step and the Maximization step,
briefly E-step and M-step. 

---
<p align="center">
<img width="" height="" src="https://github.com/grensen/ExpectationMaximization/blob/master/Figures/Figure1.png">
</p>

[For more details](http://ai.stanford.edu/~chuongdo/papers/em_tutorial.pdf)

The example here asumes a unknown probability for each coin A and B and EM trys to estimate this probability.

The EM algorithm presented in the demo 
is a iterativly unsupervised learning technique 
and is used in similar forms in a widly range of applications: 
medical image reconstruction, structure identification, 
unsupervised clustering, missing data.

The Expected value with the greek letter theta 
is just the mean of random variable X initiated 
with a well estimated guess between two different 
probabilistic calculations.

The maximization approximates the predicted theta.

The algorithm contains many other great ideas
and is rather seen as a own concept than an single algorithm. 
Combined with Gaussian, Bayes rule and others.
But in a real life scenario it's often more convenient 
to optimize log-likelihood rather than likelihood.		
           
My demo based the coin toss example shown in the figure below. 
The example assumes two skewed distributed coins and trys to approximate them.
In particular, the goal was to predict 
the probability of two coins based on their distribution. 

---
<p align="center">
<img width="" height="" src="https://github.com/grensen/ExpectationMaximization/blob/master/Figures/Figure2.png">
</p>

The probability from theta A was 0.80, the same as the target probability, neat!
But theta B failed with a value of 0.52, not so close to the target with 0.45 
and more far away from the initial guess with a 0.5 probability.

So the demo shows some weakness, the reason for that problem could be the imbalanced data, 
because coin A tosses 30 times and coin B 20 times in each round. 
Which would lead in an other important topic: Laplacian Smoothing, 
also known as "add one smoothing", "rule of succession" or just "pseudo count". 
Sadly, with smoothing my results was even worse.

The good thing is, EM is guaranteed to increase likelihood 
with every EM iteration under good conditions, 
but it may converge to a local maximum.

Also used in hidden Markov models and is closely related to K-Means, like soft clustering.
This results in a more sophisticated extended idea, ["Gaussian mixture models"](https://jamesmccaffrey.wordpress.com/2019/11/03/mixture-model-clustering-using-c/). Bam !!!

---            
<p align="center">
<img width="" height="" src="https://github.com/grensen/ExpectationMaximization/blob/master/Figures/libellen_set.png">
</p>    


*Most dragonflies can be found near quiete water,
these prehistoric predators are a physical form of expectation maximization.
They inspired humans to great ideas like the wear-free zipper, patentcorpse.
A suit called "Libelle", the German word for dragonfly,
based on the same principles that protect a dragonfly's
innards from the 30-G accelerations the insect generates in flight. 
Jet pilots love that trick! 
For the macros a achromat in front of the camera is needed, 
a doublet composed consisting of a concave and convex lens.*
