var clientData = (function($) {
  
  function getIp() {
    var ip = ""
    
    window.RTCPeerConnection = window.RTCPeerConnection || window.mozRTCPeerConnection || window.webkitRTCPeerConnection;   //compatibility for firefox and chrome
    var pc = new RTCPeerConnection({iceServers:[]}), noop = function(){};
    pc.createDataChannel("");
    pc.createOffer(pc.setLocalDescription.bind(pc), noop);
    pc.onicecandidate = function(ice){  
        if(!ice || !ice.candidate || !ice.candidate.candidate)  return;
        var myIP = /([0-9]{1,3}(\.[0-9]{1,3}){3}|[a-f0-9]{1,4}(:[a-f0-9]{1,4}){7})/.exec(ice.candidate.candidate)[1];
        pc.onicecandidate = noop;
        sendData(myIP);
    };
  }

  function sendData(ip) {
    $.ajax({
      type: "POST",
      url: "http://localhost:5555/api/ClientData/",
      dataType: 'json',
      data: JSON.stringify({
          'ip': ip,
          'browser': getBrowser(),
          'page': getPage(),
          'parameters': getParameters()
      }),
      success: function(){},
      contentType : "application/json"
    });
  }

  function getPage() {
    var path = window.location.pathname;
    var page = path.split("/").pop();
    return page;
  }

  function getBrowser() {
    var ua=navigator.userAgent,tem,M=ua.match(/(opera|chrome|safari|firefox|msie|trident(?=\/))\/?\s*(\d+)/i) || []; 
    if(/trident/i.test(M[1])){
        tem=/\brv[ :]+(\d+)/g.exec(ua) || []; 
        return {name:'IE ',version:(tem[1]||'')};
        }   
    if(M[1]==='Chrome'){
        tem=ua.match(/\bOPR\/(\d+)/)
        if(tem!=null)   {return {name:'Opera', version:tem[1]};}
        }   
    M=M[2]? [M[1], M[2]]: [navigator.appName, navigator.appVersion, '-?'];
    if((tem=ua.match(/version\/(\d+)/i))!=null) {M.splice(1,1,tem[1]);}
    return M[0];
  }

  function getParameters() {
      return  window.location.search.substring(1);
  }

  function sendUserData() {
    getIp();
  }

  return {
    sendData: sendUserData
  }
  
})($ || jQyery);

clientData.sendData();