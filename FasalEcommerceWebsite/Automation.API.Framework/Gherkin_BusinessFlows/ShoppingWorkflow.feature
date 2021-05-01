Feature: Shopping workflow to place an order for an item

@mytag
Scenario: Find and add item to the cart
	Given I am at home page
	And selected Women categeory for shopping
	And apply three filters In stock, New, Fashion and search for results
	When Add an item of worth $27 and add to cart
	Then Item should be available in the cart
	When Go to Cart Page and proceed to checkout
	And Enter username password, Address , Shipping_Details  and  Enter Address Shipping details
| email             | password     |
| atlpal1991@gmail.com | Password@123 |
	And Go to payment page and select payment type and proceed
	Then read the message in the final order confirmation summary page