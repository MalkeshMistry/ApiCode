customerModule.factory("customerService", function ($http, $q) {
    return {
        getCustomers: function () {
            // Get the deferred object
            var deferred = $q.defer();
            
            // Initiates the AJAX call
            $http({ method: 'GET', url: '/customer/GetCustomerDetails' }).success(function (response)
            {             
                deferred.resolve(response);

            })
                .error(deferred.reject);
            // Returns the promise - Contains result once request completes
            return deferred.promise;
        },
        AddCustomer: function (customer) {
            // Get the deferred object
            var deferred = $q.defer();
            debugger;
            // Initiates the AJAX call
            $http({ method: 'POST', url: '/customer/AddCustomer', data: customer }).success(deferred.resolve).error(deferred.reject);
            //$http.post('/events/AddTalk', talk).success(deferred.resolve).error(deferred.reject);
            // Returns the promise - Contains result once request completes
            return deferred.promise;
        },
        
       
        DeleteCustomer: function (customerId) {
            // Get the deferred object
            var deferred = $q.defer();
            debugger;
            // Initiates the AJAX call

            $http({ method: 'DELETE', url: '/customer/DeleteCustomer/'+ customerId  }).success(
                function (response) {
                deferred.resolve(response);

            }).error(function (response)
            {             
                
                deferred.reject();
            });
            //$http.post('/events/AddTalk', talk).success(deferred.resolve).error(deferred.reject);
            // Returns the promise - Contains result once request completes
            return deferred.promise;
        }
    }
});