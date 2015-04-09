var groupslistApp = angular.module('groupslistApp', ['ui.bootstrap', 'ui.grid']);
var groupsListCtrl = groupslistApp.controller('groupsListCtrl', ['$scope', '$http', '$modal', function ($scope, $http, $modal) {
	$scope.groups = [];
	$scope.selectedGroups = [];

	$scope.gridOptions = {
		data: 'groups',
		columnDefs: [
			{ field: 'name', displayName: 'نام گروه' },
			{ field: 'usersCount', displayName: 'تعداد اعضا' }
		]
	};

	$scope.getGroups = function () {
		$http({
			method: 'post',
			url: mathAppRootUrl + 'Home/GetGroups'
		}).success(function (data) {
			$scope.groups = data;
		});
	}

	$scope.getGroups();

	$scope.create = function (size) {
		$modal.open({
			templateUrl: 'Editor.html',
			controller: 'editorCtrl',
			size: size,
			resolve: {
				group: function () {
					return null;
				}
			}
		}).result.then(function (selectedItem) {
			$scope.getGroups();
		}, function () {
		});
	}
}]);

groupslistApp.controller('editorCtrl', ['$scope', '$http', '$modalInstance', 'group', function ($scope, $http, $modalInstance, group) {
	$scope.group = group;
	$scope.title = group ? 'ویرایش گروه' + group.name : 'ایجاد گروه جدید';
	$scope.groupPublicities = [];

	$http({
		method: 'post',
		url: mathAppRootUrl + 'Admin/GetGroupPublicities'
	}).success(function (data) {
		$scope.groupPublicities = data;
	});

	$scope.save = function () {
		//if (!validate()) {
		//	return;
		//}
		$http({
			method: 'post',
			url: mathAppRootUrl + 'Admin/SaveGroup',
			data: {
				model: $scope.group
			}
		}).success(function (data) {
			if (data) {
				$modalInstance.close();
			}
		});
	};

	$scope.cancel = function () {
		$modalInstance.dismiss('cancel');
	};
}]);