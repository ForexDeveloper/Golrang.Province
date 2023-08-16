// Call this to register your module to main application
var moduleName = 'Province';

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider',
        function ($stateProvider) {
            $stateProvider
                .state('workspace.ProvinceState', {
                    url: '/Province',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        'platformWebApp.bladeNavigationService',
                        function (bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: 'Province.helloWorldController',
                                template: 'Modules/$(Golrang.Province)/Scripts/blades/hello-world.html',
                                isClosingDisabled: true,
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['platformWebApp.mainMenuService', '$state',
        function (mainMenuService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/Province',
                icon: 'fa fa-cube',
                title: 'Province',
                priority: 100,
                action: function () { $state.go('workspace.ProvinceState'); },
                permission: 'Province:access',
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
