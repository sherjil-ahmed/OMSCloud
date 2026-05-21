window.exJquery = $;

var isLoaderShowing = false;
window.ShowLoader = function () {
  if (isLoaderShowing == false) {
    $('.loading-overlay').css({
      opacity: '0.5',
      visibility: 'visible',
    });
    isLoaderShowing = true;
  }
};

window.HideLoader = function () {
  if (isLoaderShowing == true) {
    $('.loading-overlay').css({
      opacity: '0',
      visibility: 'hidden',
    });
    isLoaderShowing = false;
  }
};

window.CreateUISlider = function (ele, maxVal, minVal, rComp) {
  if (ele.current.noUiSlider) {
    return;
  } else {
    maxVal = minVal == maxVal ? maxVal + 1 : maxVal;
    noUiSlider.create(ele.current, {
      start: [minVal, maxVal],
      connect: true,
      range: {
        min: 0,
        max: maxVal,
      },
    });

    ele.current.noUiSlider.on('update', function (values, handle) {
      let value = ele.current.noUiSlider.get();
      rComp.setState({
        MinPrice: parseInt(value[0]),
        MaxPrice: parseInt(value[1]),
      });
    });
  }

  window.setNoUiSlider = function (ele, arr) {
    if (ele.current && ele.current.noUiSlider) {
      ele.current.noUiSlider.set(arr);
    } else {
    }
  };
};

window.toggleFilter = function (isOpened) {
  let bisOpened = isOpened == 'Y' ? true : false;
  //$(".filter-toggle a").click(function (t) {
  if (bisOpened) {
    $('.filter-toggle').addClass('opened');
    $('main').addClass('sidebar-opened');
  } else {
    $('.filter-toggle').removeClass('opened');
    $('main').removeClass('sidebar-opened');
  }

  $('.sidebar-overlay').click(function (t) {
    $('.filter-toggle').removeClass('opened');
    $('main').removeClass('sidebar-opened');
  });

  $('.sort-menu-trigger').click(function (t) {
    t.preventDefault(), $('.select-custom').removeClass('opened');
    $(t.target).closest('.select-custom').toggleClass('opened');
  });
};

window.exHeaderComp;
window.exposeMobileMenuComp;

window.MoveToDiv = function (id) {
  $('html, body').animate(
    {
      scrollTop: $('#' + id).offset().top,
    },
    2000,
  );
};

window.createProductCarousle = function (ele) {
  var e = $;
  var t = {
    loop: !0,
    margin: 0,
    responsiveClass: !0,
    nav: !1,
    navText: [
      '<i class="icon-left-open-big">',
      '<i class="icon-right-open-big">',
    ],
    dots: !0,
    autoplay: !0,
    autoplayTimeout: 15e3,
    items: 1,
  };

  e(ele.current).owlCarousel(
    e.extend(!0, {}, t, {
      nav: !0,
      navText: ['<i class="icon-angle-left">', '<i class="icon-angle-right">'],
      dotsContainer: '#carousel-custom-dots',
      autoplay: !1,
      onInitialized: function () {
        var t = this.$element;
        e.fn.elevateZoom &&
          t.find('img').each(function () {
            var t = e(this),
              i = {
                responsive: !0,
                zoomWindowFadeIn: 350,
                zoomWindowFadeOut: 200,
                borderSize: 0,
                zoomContainer: t.parent(),
                zoomType: 'inner',
                cursor: 'grab',
              };
            t.elevateZoom(i);
          });
      },
    }),
  );

  e('#carousel-custom-dots .owl-dot').click(function () {
    e('.product-single-carousel').trigger('to.owl.carousel', [
      e(this).index(),
      300,
    ]);
  });
};

window.createTouchspinElementVertical = function (ele, callbackFunc) {
  var e = $;
  e.fn.TouchSpin &&
    e(ele.current).TouchSpin({
      verticalbuttons: !0,
      verticalup: '',
      verticaldown: '',
      verticalupclass: 'icon-up-dir',
      verticaldownclass: 'icon-down-dir',
      buttondown_class: 'btn btn-outline',
      buttonup_class: 'btn btn-outline',
      initval: 1,
      min: 1,
    });

  e(ele.current).on('touchspin.on.startspin', function (event) {
    if (callbackFunc) callbackFunc(event.target.value);
  });
};

window.createTouchspinElementHorizontal = function (ele, callbackFunc) {
  var e = $;
  e.fn.TouchSpin &&
    e(ele.current).TouchSpin({
      verticalbuttons: false,
      buttonup_txt: '',
      buttondown_txt: '',
      buttondown_class: 'btn btn-outline btn-down-icon',
      buttonup_class: 'btn btn-outline btn-up-icon',
      initval: 1,
      min: 1,
    }),
    e(ele.current).on('touchspin.on.startspin', function (event) {
      if (callbackFunc) callbackFunc(event.target.value);
    });
};

window.HookProductModal = function (ele, callbackFunc) {
  $(ele.current).on('hidden.bs.modal', function (event) {
    if (callbackFunc) callbackFunc();
  });
};

window.ValidateForm = function (eleSubmit, eleForm, callbackFunc) {
  if (!$(eleForm.current)[0].checkValidity()) {
    $(eleForm.current).find(':submit').click();
  } else {
    callbackFunc();
  }
};

window.createSummerNote = function (ele, callbackFunc, HTMLstring) {
  $(ele.current).summernote();
  $('.dropdown-toggle').dropdown();

  if (HTMLstring) {
    $(ele.current).summernote('code', HTMLstring);
  }

  $(ele.current).on('summernote.change', function (we, contents, $editable) {
    if (callbackFunc) {
      let code = $(ele.current).summernote('code');
      callbackFunc(code, we, contents, $editable);
    }
  });
};

window.exposeCardHeader = null;
window.exposeUserHeader = null;
window.hub = null;
window.exposeMobileMenu = null;

window.initWebSocketConnection = function (baseUrl, profileID, callbackFunc) {
  window.hub = $.connection.notificationHub;
  $.connection.hub.url = baseUrl + '/signalr';
  $.connection.hub.qs = { ProfileID: profileID };

  window.hub.client.broadCastMessage = function (msg) {
    if (
      callbackFunc &&
      window.location.pathname != '/chat' /*&& msg.NotificationType != '2'*/
    )
      callbackFunc(msg);

    // Dispatch the event.
    window.dispatchEvent(new CustomEvent('gotMessage', { detail: msg }));
  };

  $.connection.hub.start().done(() => {});
};

//SignalR function expose
window.startWebSocketConnection = function (baseUrl, profileID, callbackFunc) {
  var script = document.createElement('script');
  if (script.readyState) {
    //IE
    script.onreadystatechange = function () {
      if (script.readyState === 'loaded' || script.readyState === 'complete') {
        script.onreadystatechange = null;
        //alert(jQuery);
        window.initWebSocketConnection(baseUrl, profileID, callbackFunc);
      }
    };
  } else {
    //others
    script.onload = function () {
      window.initWebSocketConnection(baseUrl, profileID, callbackFunc);
    };
  }
  script.src = baseUrl + '/signalr/hubs';
  document.documentElement.appendChild(script);

  // Create WebSocket connection.

  // let hubName = 'notificationhub'
  // $.get(`http://localhost:8749/signalr/negotiate?clientProtocol=1.5&ProfileID=${profileID}&connectionData=%5B%7B%22name%22%3A%22${hubName}%22%7D%5D`,(negotiations)=>{
  //     console.log(negotiations)
  //     let token = encodeURIComponent(negotiations.ConnectionToken);
  //     const socket = new WebSocket(`ws://localhost:8749/signalr/connect?transport=webSockets&clientProtocol=1.5&ProfileID=${profileID}&connectionToken=${token}&connectionData=%5B%7B%22name%22%3A%22${hubName}%22%7D%5D&tid=7`);

  //     // Connection opened
  //     socket.addEventListener('open', function (event) {
  //         socket.send('Hello Server!');
  //     });

  //     // Listen for messages
  //     socket.addEventListener('message', function (event) {
  //         console.log('Message from server ', event.data);
  //     });

  //     $.get(`http://localhost:8749/signalr/start?transport=webSockets&clientProtocol=1.5&ProfileID=${profileID}&connectionToken=${token}&connectionData=%5B%7B%22name%22%3A%22${hubName}%22%7D%5D`,(connect)=>{
  //         console.log(connect)
  //     })
  // })
};

//Service Worker
window.RegisterServiceWorker = function () {
  if ('serviceWorker' in navigator) {
    navigator.serviceWorker.register('/assets/js/service-worker/sw.js');
  }
};

//Request Notification permission
window.RequestNotificationPermission = function () {
  Notification.requestPermission(function (status) {});
};

//display notification
window.displayNotification = function () {
  if (Notification.permission == 'granted') {
    navigator.serviceWorker.getRegistration().then(function (reg) {
      new window.Notification('Hello World');
    });
  }
};

window.handleLanguageChange = function (data) {
  if ($('.goog-te-combo')) {
    let a = Object.entries($('.goog-te-combo')[0].options).find(
      (a) => a[1].value == data,
    );
    if (a) {
      $('.goog-te-combo')[0].value = data;
      $('.goog-te-combo')[0].dispatchEvent(new Event('change'));
      $('.goog-te-combo')[0].dispatchEvent(new Event('change'));
    } else {
      console.log('Language does not exists');
    }
  } else {
    console.log('translate not loaded as yet');
  }
};

window.openModal = function (id) {
  $('#' + id).modal('show');
};

window.dismissModal = function (id) {
  $('#' + id).modal('hide');
};

window.DirtyFlag = false;
window.onbeforeunload = function (e) {
  if (window.DirtyFlag) {
    return '';
  } else {
  }
};

//just for safe keeping
window.onunload = function (e) {
  window.DirtyFlag = false;
};

window.bindMobmenuOptions = function () {
  let expandArray = document.querySelectorAll('.expand');
  let buttonArray = document.querySelectorAll('.click-to-expand');

  document.querySelectorAll('.click-to-expand').forEach(function (i) {
    i.addEventListener('click', function (e) {
      const clickedBtnIndex = [...buttonArray].indexOf(e.target);
      expandArray[clickedBtnIndex].classList.toggle('hidden');
    });
  });
};

window.appConfig = {};
window.GetConfiguration = function () {
  fetch('/mainfest.json').then((res) =>
    res.json().then((data) => {
      appConfig = data;
      document.dispatchEvent(new Event('configLoaded'));
      //return data;
    }),
  );
};

window.attachJS = function () {
  console.log('js attached');
  $('ul.in-side-menu.submenu li').on('mouseover', (e) => {
    //console.log('menu hovered',e.currentTarget.offsetTop)
    //console.log('menu childern height',e.currentTarget.children[1])
    //if(e.currentTarget.offsetTop + e.currentTarget.children[1].clientHeight <= window.innerHeight){
    e.currentTarget.children[1].style.top = e.currentTarget.offsetTop + 'px';
    //}
    //else{
    //}
  });
};

window.openNavChild = function (i,title) {
  $('.Categorie').hide();
  $('.child-cat' + i).show();
  $('.Categorie-name').text(title)
};

window.openNavSub = function (i, j, title) {
  $('.Categorie-child').hide();
  $('.ct' + i + 'c' + j + 's' + j + 'b').show();
  $('.Categorie-name').text(title)
};

window.mainClose = function () {
  $('.Categorie').show();
  $('.Categorie-child').hide();
  $('.Categorie-name').text("Browse Categories")
};

window.childClose = function (i, prevTitle) {
  $('.child-cat'+i).show();
  $('.Categorie-sub').hide();
  console.log("prevTitle",prevTitle)
  $('.Categorie-name').text(prevTitle)
};

window.openSublvl2 = function(i, j, k, title) {
  $(".Categorie"+i+"-child"+j+"-sub-child"+k).show();
  $(".Categorie-sub").hide();
  $('.Categorie-name').text(title)
};

window.sublvl2Close = function(i, j ,k , prevTitle){
  $(".Categorie"+i+"-child"+j+"-sub-child"+k).hide();
  $(".ct"+i+"c"+j+"s"+j+"b").show();
}
