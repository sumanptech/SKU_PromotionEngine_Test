# PromotionEngine 
 
 **Promotion_Engine : A solution to caluculate final Checkout Price for list of SKUs**

**Problem Statement**   
Implement a simple promotion engine for a checkout process. Cart contains a list of single character SKU ids (A, B, C. ) over which the promotion engine will need to run. The promotion engine will need to calculate the total order value after applying the 2 promotion types • buy 'n' items of a SKU for a fixed price (3 A's for 130) • buy SKU 1 & SKU 2 for a fixed price ( C + D = 30 ) The promotion engine should be modular to allow for more promotion types to be added at a later date (e.g. a future promotion could be x% of a SKU unit price).

Test Setup Unit price for SKU IDs A 50 B 30 C 20 D 15

Active Promotions 3 of A's for 130 2 of B's for 45 C & D for 30

Scenario A 1 * A 50 1 * B 30 1 * C 20

Total 100 Scenario B 5 * A 130 + 2*50 5 * B 45 + 45 + 30 1 * C 28

Total 370

Scenario C 3 * A 130 5 * B 45 + 45 + 1 * 30 1 * C - 1 * D 30 Total 280

**Environment and Solution Framework properties**    

.Net Framework 4.7.2.
Language: C#
Each section of solution is Independent and each class libraries can be deployed in multi layer (each on Individual server) environment
Modules like Helper and Loggers can be shared across Projects

**Extenal Dependencies**  

1) Data Layer is depeendent on following Nuget Packages:

a) Microsoft.Extensions.Configuration (5.0.0)   
b) Microsoft.Extensions.Configuration.Binder (5.0.0)   
c) Microsoft.Extensions.Configuration.JSON (5.0.0)  

2) User Module are depeendent on following Nuget  Packages:

a) Microsoft.Extensions.Configuration (5.0.0)   
b) Microsoft.Extensions.Configuration.Binder (5.0.0)   
c) Microsoft.Extensions.Configuration.JSON (5.0.0)   
d) Microsoft.Extensions.Configuration.FileExtension   
e) Microsoft.Extensions.Configuration.Abstraction   
f) Microsoft.Extensions.FileProviders.Abstraction   

**Development Environment Setup**
1) Make sure Visual studio latest version supporting .Net Framework 4.7.2 and .Net Standard application is installed.
2) Machine is connected to internet
3) No security applied on Nuget package manager installation, if there is security, please point to local repository manager having above mentioned packages.
4) clone the repository 
5) Set PromotionEngine as startup project
6) Install above mentioned Nuget packages
7) Build the Solution.
8) Run to see it working
In case of error, see if Nuget packages are still available and version 5.0.0 is not yet obsolete.
In case you need to amend data in Data Source. Data Source is placed at.... #"Promotion_Engine\SKU_PromotionEngine\PromotionEngine.User\bin\Debug"
