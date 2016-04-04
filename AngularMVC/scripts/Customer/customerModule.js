var customerModule = angular.module("customerModule", []).config(function ($routeProvider, $locationProvider) {
    //Path - it should be same as href link
    debugger;
    $routeProvider.when('/Customer/GetCustomer', { templateUrl: '/Template/Customer.html', controller: 'customerController' });
    $routeProvider.when('/Customer/AddCustomer', { templateUrl: '/Template/AddCustomer.html', controller: 'customerController' });
    $locationProvider.html5Mode(true);
});