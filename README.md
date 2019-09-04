# OpenPay - Coding Exercise -----------------
Context
Openpay customers can buy goods and pay the purchase price over time on a payment plan. Customers pay a deposit at the time of purchase, take the goods home and pay the remainder as installments.
The required deposit and installment interval and period dependon the purchase price, as shown below.
Purchase Price ($)	Deposit (% of Purchase)	Installment interval	Number of Installments
Price < 100 	Plans not offered	Plans not offered	Plans not offered
100 <= Price < 1000 	20%	15 days 	5 
100 <= Price < 1000	30% 	15 days	4
1000 <= Price < 10000 	25% 	30 days 	4 
Price >= 10000 	Plans not offered 	Plans not offered	Plans not offered
 
Task
Write a sample ‘plan calculator’ application that satisfies the payment plan rules.  
# End of Exercise -----------------------------

# How to Use the Solution
1. Clone repo
2. Ppen using VS2019
3. Build solution and start API
4. Use postman or any other tool and type in below request

# Request
Method - GET </br>
Url - [yourApplicationUrl]/api/PlanCalculator </br>
Body -  </br>
{ </br>
"PurchasePrice" : [Float Value], </br>
"PurchaseDate": "[DateTime Value]" </br>
} </br>
Headers - Content-Type : application/json

# Example Request And Response
Request -  </br>
{ </br>
"PurchasePrice" : 199, </br>
"PurchaseDate": "03/24/2019" </br>
} </br>

Response - </br>
{ </br>
    "deposit": 39.8, </br>
    "amount": 31.84, </br>
    "dates": [ </br>
        "8/04/2019", </br>
        "23/04/2019", </br>
        "8/05/2019", </br>
        "23/05/2019", </br>
        "7/06/2019" </br>
    ] </br>
}


