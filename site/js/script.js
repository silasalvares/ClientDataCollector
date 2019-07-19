$.ajax({
    type: 'GET',
    url: 'https://localhost:5001/api/ClientData'
});

$.ajax({
    type: 'POST',
    url: 'https://localhost:5001/api/ClientData',
    contentType : "application/json",
    data: {'teste': 'teste'}
});