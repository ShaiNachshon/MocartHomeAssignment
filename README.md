# Instructions:
GitHub Repository: [Repository](https://github.com/ShaiNachshon/MocartHomeAssignment)  
Play the Project: [Project Link](https://play.unity.com/en/games/ef02483a-0a69-4370-9a7b-7653e49156a2/mocart-home-assignment)

## Assets Used:
[Error Exclamation Mark](https://www.flaticon.com/free-icon/exclamation-mark_8631570)

## How to use:
- Use A/D or ←/→ to move sideways (optional, for convenience).  
- Click the 'New Shop' button to fetch server data and instantiate a new shop with corresponding products.  
- Click the 'Update Shop' button to open a user-friendly interface, where you can modify product data and view feedback on your changes.  
- Click the 'Save Changes' button to save your modifications. Feedback will notify you whether changes were successful or if there were errors.  
- If errors are found, exclamation marks will appear next to invalid input fields. Hover over them (or tap on mobile) to view the error details.  
- The UI dynamically updates based on the number of products in the shop. You may click the 'New Shop' button to change the product count and re-open the UpdateShop UI for testing.  

## Project overview:
- `PlayerMovement` handles sideways movement using A/D or ←/→.  
- `ProductServerFetcher` fetches server data.  
- `ProductInstantiater` instantiates products and keeps them in memory for future updates.  
- `ProductData` & `ProductList` hold product data and act as server data containers.  
- `ProductDisplay` displays product data (name, price, description).  
- `ShopUIUpdater` instantiates `ShopProductCard` panels based on their data (name, price, description).  
- `ShopProductCard` handles the panels where you view and edit product information in the 'Update Shop' UI.  

## Final thoughts:
This project is a simple white-boxing prototype built in under a day due to balancing reserve service duties in the army. While the project is basic, I hope it demonstrates my capabilities and meets the expected standards. Although there wasn't much room to showcase advanced software design, the project effectively conveys the core concept.
