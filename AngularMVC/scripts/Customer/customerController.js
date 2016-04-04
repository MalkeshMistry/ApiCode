customerModule.controller("customerController", function ($scope, $location, customerService) {
    customerService.getCustomers().then(
        
        function (response)
        {
            debugger;
            $scope.customers = response
        },
        function ()
        {
            alert('error while fetching customers from server')
        }),
     $scope.add = function (customer) {
         customerService.AddCustomer(customer).then(function () { $location.url('/Customer/GetCustomer'); }, function ()
         { alert('error while adding talk at server') });
     };
    $scope.delete = function (customerId) {
        customerService.DeleteCustomer(customerId).then(
            function (response) {
                alert('Record successfully deleted')
                $location.url('/Customer/index');
        },
        function () {
            alert('error while fetching customers from server')
        });
    };
});