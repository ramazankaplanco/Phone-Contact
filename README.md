# Phone Contact
Asp.Net MVC 5 with 3 Layer Architecture Design

## About System

   - We designed the system for a company employees to communication to each other, in same time we designed with 3 Layer Architecture.
   
   _Technology Patterns_
   1. Unit of Work
   2. Business Layer
   3. Repository (Data Access) 
   
   _Design Patterns_
   1. Singleton Pattern (Single Service and UOW Instance)
   2. Dependency Injection Pattern (Repository inject to Service constructor)
   ...

## Getting Started to Phone Contact

## Get Token for OAuth Bearer Authentication

   ** After user login we get token for user access to application pages. 
   
   We should confirm if user has right token with `[Authorize]` attribute with UI and API controllers.
      
   In the feature we will add permissions for every CRUD operations attribute to `GET, POST, PUT, DELETE` header methods.
   
   Now get testing auth bearer 2.0 configurations for get `access_token` and do CRUD operations.
   

   #### HTTP RESTfull 
      
   * url: `http://localhost:54234/token`
   
   * method: `POST` 

   * header parameters:
   
   
    ` 
        Content-Type:application/x-www-form-urlencoded
    `
    
   * body parameters: 
   
   
    `
        grant_type:password
        username:admin@admin.com
        password:Admin123.
     `
     
   * response: We added `userName` extra to `\PhoneContact\PhoneContact\Providers\ApplicationOAuthProvider.cs`
               with `CreateAuthProperties` method
   
   
    `
        {
            "access_token": "jFKHBA1fcwUSVDrLuFfvVlgRFLYJpS4Jf-XpEzNj_hXd8SVYr87tLhgXU1DF80sYunvb-p9h-ZDCiOvF9w_UulehHFh_CUtlDTnf1d4TM5KZ5Xh-mi9r2TZhPv6myyzFZ59K5Z0JBN_ciWQJm_faM9sGO14NXIcV_b_rbBjF0U1j4YDToKS-d6Um6gCDZ_XoOuWy7eA5rBZct2BeuA8j42qVfZhjD0UndiQAWTsscvU",
            "token_type": "bearer",
            "expires_in": 1209599,
            "userName": "admin@admin.com",
            ".issued": "Thu, 18 Jun 2020 20:39:04 GMT",
            ".expires": "Thu, 02 Jul 2020 20:39:04 GMT"
        }
    `
    
## Using `access_token` for API CRUD Operations
    
   ** After get token we can do anything for `GET, POST, PUT, DELETE` HTTP Methods.
    
   * url: `http://localhost:54234/api/Department` 
   
   * method: `GET` 
   
   
   * header parameters:
      
      
      
       ` 
           Accept:application/json
           Authorization:bearer jFKHBA1fcwUSVDrLuFfvVlgRFLYJpS4Jf-XpEzNj_hXd8SVYr87tLhgXU1DF80sYunvb-p9h-ZDCiOvF9w_UulehHFh_CUtlDTnf1d4TM5KZ5Xh-mi9r2TZhPv6myyzFZ59K5Z0JBN_ciWQJm_faM9sGO14NXIcV_b_rbBjF0U1j4YDToKS-d6Um6gCDZ_XoOuWy7eA5rBZct2BeuA8j42qVfZhjD0UndiQAWTsscvU
       `
   
   
   
   * response:
      
      
      
       `
           {
               "message": null,
               "success": true,
               "data": [
                   {
                       "departmentName": "HR",
                       "departmentCode": "HR001",
                       "departmentNote": null,
                       "id": 1,
                       "isDeleted": false
                   },
                   {
                       "departmentName": "IT",
                       "departmentCode": "IT0002",
                       "departmentNote": null,
                       "id": 2,
                       "isDeleted": false
                   }
               ]
           }
       `