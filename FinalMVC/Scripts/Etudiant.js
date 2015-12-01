$(document).ready(function () {
    $('#listecours').DataTable({
        columnDefs: [{
            targets: [0],
            orderData: [0, 1]
        }, {
            targets: [1],
            orderData: [1, 0]
        }, {
            targets: [2],
            orderData: [2, 1]
        }]
    });
});
$(document).ready(function () {
    $('#listeclasses').DataTable({
        columnDefs: [{
            targets: [0],
            orderData: [0, 1]
        }, {
            targets: [1],
            orderData: [1, 0]
        }, {
            targets: [2],
            orderData: [2, 1]
        }]
    });
});
$(document).ready(function () {
    $('#listeexamens').DataTable({
        columnDefs: [{
            targets: [0],
            orderData: [0, 1]
        }, {
            targets: [1],
            orderData: [1, 0]
        }, {
            targets: [2],
            orderData: [2, 1]
        }]
    });
});
$(document).ready(function () {
    $('#listeutilisateurs').DataTable({
        columnDefs: [{
            targets: [0],
            orderData: [0, 1]
        }, {
            targets: [1],
            orderData: [1, 0]
        }, {
            targets: [2],
            orderData: [2, 1]
        }]
    });
});
$(document).ready(function () {
    $('#listeprofesseurs').DataTable({
        columnDefs: [{
            targets: [0],
            orderData: [0, 1]
        }, {
            targets: [1],
            orderData: [1, 0]
        }, {
            targets: [2],
            orderData: [2, 1]
        }]
    });
});
$(document).ready(function () {
    $('#listeetudiants').DataTable({
        columnDefs: [{
            targets: [0],
            orderData: [0, 1]
        }, {
            targets: [1],
            orderData: [1, 0]
        }, {
            targets: [2],
            orderData: [2, 1]
        }]
    });
});