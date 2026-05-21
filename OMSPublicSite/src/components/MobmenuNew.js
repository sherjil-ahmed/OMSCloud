import React from 'react';
import {
  getStorageItem,
  clearStorage,
  setStorageItem,
} from '../utils/storageHelper';
import {
  SERVICE_ENDPOINTS,
  REQUEST_TYPE,
  LIST_CATEGORY,
  IS_USER_LOGGEDIN,
  LAST_CAT_FETECHED_DATETIME,
} from '../utils/constants';
import Helmet from 'react-helmet';
import { baseUrlImage, FetchData } from '../utils/serviceHelper';
import moment from 'moment';
class MobileMenu extends React.Component {
  constructor() {
    super();
    this.state = {
      bodyClassList: window.document.body.classList,
      listCategory: getStorageItem(LIST_CATEGORY)
        ? getStorageItem(LIST_CATEGORY)
        : [],
    };
  }
  componentDidMount() {
    window.exposeMobileMenuComp = this;
    window.exposeMobileMenu = this.updateMobileMenu;
    if (!(this.state.listCategory && this.state.listCategory.length > 0)) {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Category_GetCategoryList,
        null,
        this.successGetCategoryList,
      );
    }
  }
  successGetCategoryList = (res) => {
    setStorageItem(LAST_CAT_FETECHED_DATETIME, moment().format("DD/MM/YYYY HH:mm:ss"));
    let sessionProfile = getStorageItem(IS_USER_LOGGEDIN);
    let _listCategory = this.state.listCategory;

    for (let item of res) {
      item.ParentsList = [];
      item.ParentsList = this.getParentsList(item.CategoryParentID, res);
    }
    _listCategory = res;
    this.setState(
      {
        listCategory: _listCategory,
        doesSessionExists: sessionProfile ? true : false,
      },
      () => {
        setStorageItem(LIST_CATEGORY, this.state.listCategory);
      },
    );
  };
  getParentsList = (categoryId, list) => {
    let parent = list.find((a) => a.CategoryID == categoryId);
    if (parent) {
      if (parent.ParentCategoryID) {
        return [...this.getParentsList(parent.ParentCategoryID, list), parent];
      } else {
        //base condition
        let temp = new Array();
        temp.push(parent);
        return temp;
      }
    } else {
      return [];
    }
  };

  updateMobileMenu = (obj) => {
    console.log('updateMobileMenu called');
    this.setState(
      {
        bodyClassList: window.document.body.classList,
      },
      () => {
        window.bindMobmenuOptions();
      },
    );
  };

  render() {
    if (this.state.bodyClassList.contains('mmenu-active')) {
      let mainCategories =
        this.state.listCategory && this.state.listCategory.length > 0
          ? this.state.listCategory.filter((a) => a.CategoryTypeID == 1)
          : [];
      let sublvl1Categories =
        this.state.listCategory && this.state.listCategory.length > 0
          ? this.state.listCategory.filter((a) => a.CategoryTypeID == 2)
          : [];
      let sublvl2Categories =
        this.state.listCategory && this.state.listCategory.length > 0
          ? this.state.listCategory.filter((a) => a.CategoryTypeID == 3)
          : [];
      let sublvl3Categories =
        this.state.listCategory && this.state.listCategory.length > 0
          ? this.state.listCategory.filter((a) => a.CategoryTypeID == 4)
          : [];
      let childCategories =
        this.state.listCategory && this.state.listCategory.length > 0
          ? this.state.listCategory.filter(
              (a) => a.ParentsList && a.ParentsList.length > 0,
            )
          : [];
      return (
        <>
          <Helmet
            style={[
              {
                cssText: `
          
        /*mobile des*/
        @media only screen and (max-width: 768px) {
            .close {
                top: 12px !important;
                font-size: 14px !important;
            }	
			.top-cont h2 {
				font-size: 17px;
			}
			.m-close {
				top: -11px !important;
			}
        }
		@media only screen and (max-width: 767px) {
            .close {
				right: 0;
				font-size: 20px;
				font-family: cursive;
				padding: 7px 13px;
				cursor: pointer;
				text-align: end;
				display: inline-block;
				width: fit-content;
				margin-bottom: 10px;
				margin-top: 10px;
				position: absolute;
				top: -50px !important;
			}	
			.top-cont h2 {
				font-size: 17px;
			}
			.m-close {
				top: -9px !important;
			}
        }
        @media only screen and (max-width: 600px) {
            .close {
                top: -13px !important;
                font-size: 12px !important;
            }
			.main-mobile {
				width: 70% !important;
			}


        }
        @media only screen and (max-width: 440px) {
            .main-mobile {
                width: 100% !important;
                height: 84% !important;
                position: absolute !important;
                bottom: 0 !important;
				        top: 0px !important;
            }

            .close {
				right: 16px !important;
				margin-top: -45px !important;
				top: 12px !important;
			}
            .mobile-nav-body {
                overflow-y: scroll;
            }
            @keyframes mymove {
                from   {
                    width: 0%;
                    opacity: 0;
                    height: 0%;
                }
                to {
                    width: 100%;
                    opacity: 1;
                    height: 70%;
                }
            }
			
			
        }
        /*mobile des*/
        .click {
            width: fit-content;
        }
        .click span {
            color: #fff;
            padding: 14px 14px;
            display: block;
            border: 1px solid;
            width: fit-content;
            margin: 15px;
        }
		.container.top-cont {
			width: 100%;
		}
        .main-mobile {
            width: 50%;
            margin: 0;
            background: #fff;
            position: absolute; 
            overflow: scroll;
            box-sizing: border-box;
            // box-shadow: 6px 20px 43px 7px #150101;
            padding-top: 4px;
            padding-bottom: 54px;
            height: 100%;
            /* display: none; */
            z-index: 9999;
            animation: mymove 1s;
			top: 0%;
        }
        @keyframes mymove {
            from   {
                width: 0%;
                opacity: 0;
            }
            to {
                width: 50%;
                opacity: 1;
            }
        }
        .mobile-top-bar {
            position: relative;
            overflow: hidden;
            border-bottom: 2px solid;
            display: block;
            margin-bottom: 32px;
            // box-shadow: 3px 11px 15px 2px #776b6b;
            padding: 2px 13px;
        }
        .mobile-top-bar img {
            width: 16%;
        }
		
        .close {
            right: 16px;
			cursor: pointer;
			text-align: end;
			display: inline-block;
			width: fit-content;
			float: right;
			margin-bottom: 10px;
			margin-top: 10px;
        }
        p.close.m-close i {
          color: #000;
          font-size: 25px;
      }
        .mobile-nav-body {
            padding: 12px;
        }
        .Categorie {
            background: #f1f0f0;
            position: relative;
            border-bottom: 2px solid #dad7d7;
            padding: 7px 12px;
        }
        .Categorie a {
            color: #000;
            font-size: 18px;
            font-weight: 600;
            text-decoration: none;
        }
        .Categorie span i {
            font-size: 23px;
            font-weight: 700;
            display: inline-block;
            position: absolute;
            right: 16px;
        }
        .Categorie-child {
            position: relative;
            padding: 10px 12px;
            border-bottom: 2px solid #dad7d7;
            display: none;
            width: 100%;
        }
        .Categorie-child a {
            color: #000;
            font-size: 18px;
            font-weight: 600;
            text-decoration: none;
			padding-left: 14px;
        }
        .Categorie-child span i {
            font-size: 23px;
            font-weight: 700;
            display: inline-block;
            position: absolute;
            right: 16px;
        }
        .Categorie-sub.child {
            display: none;
            width: 100%;
        }
        .Categorie-sub.child ul {
            list-style-type: none;
            padding: 0px;
        }
        .Categorie-sub.child ul li a {
            color: #000;
            text-decoration: none;
            font-size: 18px;
            font-weight: 600;
            border-bottom: 2px solid #463737;
            display: block;
            padding: 13px 2px;
        }
        span.cat-close i {
            position: absolute;
			display: block;
			font-size: 16px;
			top: -16px;
			right: auto;
			color: #000;
			padding: 11px 14px;
			border-radius: 4px;
			cursor: pointer;
        }
        span.cat-close {
            display: block;
            margin-bottom: 32px;
        }
		.cat1-close-sub i {
			display: block;
			font-size: 16px;
			right: auto;
			color: #000;
			padding: 11px 14px;
			border-radius: 4px;
			cursor: pointer;
    }
    /*new*/
		.Categorie1-child1-sub-child1 {
			display: none;
		}
		.Categorie1-child1-sub-child1 ul {
			list-style-type: none;
			padding: 0;
		}
		.Categorie-sub.child.ct1c1s1b ul li {
			position: relative;
		}
		.Categorie1-child1-sub-child1 ul li a {
			color: #000;
			font-size: 17px;
			line-height: 28px;
			display: block;
			border-bottom: 2px solid #463737;
			padding: 8px 0;
			font-weight: 700;
		}
		span.sun-child-oper i {
			font-size: 23px;
			font-weight: 700;
			display: inline-block;
			position: absolute;
			right: 16px;
			top: 12px;
		}
          `,
              },
            ]}
          ></Helmet>
          <div class="main-mobile">
            <div class="mobile-top-bar">
              <div class="container top-cont">
                <div class="row">
                  <div class="col-sm-6">
                    <h2 class="Categorie-name">Browse Categories</h2>
                  </div>
                  <div class="col-sm-6">
                    <p
                      class="close m-close"
                      onClick={(e) => {
                        e.preventDefault();
                        window.document.body.classList.remove('mmenu-active');
                        this.updateMobileMenu();
                      }}
                      

                    >
                      <i class="fa fa-window-close" aria-hidden="true"></i>
                    </p>
                  </div>
                </div>
              </div>
            </div>
            {mainCategories && mainCategories.length > 0 ? (
              (() => {
                let arrOptions = [];
                for (let i = 0; i < mainCategories.length; i++) {
                  if (i >= 7) {
                    break;
                  }
                  let item = mainCategories[i];
                  if (item.IsSystem === true && item.CategoryTypeID === 1) {
                    let option = (
                      <>
                        <div className="Categorie">
                          <a href="#">{item.CategoryTitle} </a>
                          <span
                            className={'cat' + (i + 1)}
                            onClick={() => {
                              window.openNavChild(i + 1, item.CategoryTitle);
                            }}
                          >{sublvl1Categories.filter(
                            (f) => f.CategoryParentID == item.CategoryID,
                          ) && sublvl1Categories.filter(
                            (f) => f.CategoryParentID == item.CategoryID,
                          ).length > 0 ? 
                          <i
                              className="fa fa-angle-right cat"
                              aria-hidden="true"
                            />
                          : <></>}
                            
                          </span>
                        </div>
                      </>
                    );
                    arrOptions.push(option);

                    let arrChildCategories = sublvl1Categories.filter(
                      (f) => f.CategoryParentID == item.CategoryID,
                    );

                    for (let j = 0; j < arrChildCategories.length; j++) {
                      let childitem = arrChildCategories[j];
                      let childoption = (
                        <div className={'Categorie-child child-cat' + (i + 1)}>
                          {j == 0 ? (
                            <span
                              className="cat-close"
                              onClick={() => {
                                window.mainClose();
                              }}
                            >
                              <i
                                className="fa fa-chevron-left"
                                aria-hidden="true"
                              >
                                {' '}
                                &nbsp; &nbsp;Back{' '}
                              </i>
                            </span>
                          ) : (
                            <></>
                          )}
                          <a
                            href={
                              '/search?' +
                              `CategoryID=${childitem.CategoryID}&openFilter=${this.state.openFilter}`
                            }
                          >
                            {' '}
                            {childitem.CategoryTitle}
                          </a>
                          <span
                            className={
                              'cat' +
                              (i + 1) +
                              '-child' +
                              (j + 1) +
                              '-sub' +
                              (j + 1)
                            }
                            onClick={() => {
                              window.openNavSub(
                                i + 1,
                                j + 1,
                                childitem.CategoryTitle,
                              );
                            }}
                          >
                            {sublvl2Categories.filter(
                              (f) => f.CategoryParentID == childitem.CategoryID,
                            ) &&
                            sublvl2Categories.filter(
                              (f) => f.CategoryParentID == childitem.CategoryID,
                            ).length > 0 ? (
                              <i
                                className="fa fa-angle-right"
                                aria-hidden="true"
                              />
                            ) : (
                              <></>
                            )}
                          </span>
                        </div>
                      );
                      arrOptions.push(childoption);

                      let arrSubCategories = sublvl2Categories.filter(
                        (f) => f.CategoryParentID == childitem.CategoryID,
                      );

                      let arrtempoptions = [];
                      let _arrOptionsNew = [];
                      for (let k = 0; k < arrSubCategories.length; k++) {
                        let subitem = arrSubCategories[k];
                        let tempoptions = (
                          <li>
                            <a
                              href={
                                '/search?' +
                                `CategoryID=${subitem.CategoryID}&openFilter=${this.state.openFilter}`
                              }
                            >
                              {subitem.CategoryTitle}
                            </a>
                          </li>
                        );
                        arrtempoptions.push(tempoptions);

                        // Lvl 4 categories
                        // let arrSublvl2Categories = sublvl3Categories.filter(
                        //   (f) => f.CategoryParentID == subitem.CategoryID,
                        // );
                        // let arrsubtempoptions = [];

                        // for (let l = 0; l < arrSublvl2Categories.length; l++) {
                        //   let sublvl2item = arrSublvl2Categories[l];
                        //   let sublvl2 = (
                        //     <li>
                        //       <a
                        //         href={
                        //           '/search?' +
                        //           `CategoryID=${sublvl2item.CategoryID}&openFilter=${this.state.openFilter}`
                        //         }
                        //       >
                        //         {sublvl2item.CategoryTitle}
                        //       </a>
                        //     </li>
                        //   );
                        //   arrsubtempoptions.push(sublvl2);
                        // }

                        // if (arrsubtempoptions && arrsubtempoptions.length > 0) {
                        //   _arrOptionsNew.push(
                        //     <div
                        //       class={
                        //         'Categorie' +
                        //         (i + 1) +
                        //         '-child' +
                        //         (j + 1) +
                        //         '-sub-child' +
                        //         (k + 1)
                        //       }
                        //     >
                        //       <span
                        //         class={'inner-close-sub' + (i + 1)}
                        //         onClick={() =>
                        //           window.sublvl2Close(
                        //             i + 1,
                        //             j + 1,
                        //             k + 1,
                        //             sublvl2item.CategoryTitle,
                        //           )
                        //         }
                        //       >
                        //         <i class="fa fa-chevron-left" aria-hidden="true">
                        //           &nbsp; &nbsp;Back
                        //         </i>
                        //       </span>
                        //       <ul>{arrsubtempoptions}</ul>
                        //     </div>
                        //   );
                        // }
                      }
                      if (arrtempoptions && arrtempoptions.length > 0) {
                        arrOptions.push(
                          <div
                            className={
                              'Categorie-sub child ' +
                              'ct' +
                              (i + 1) +
                              'c' +
                              (j + 1) +
                              's' +
                              (j + 1) +
                              'b'
                            }
                          >
                            <span
                              className={'cat' + (i + 1) + '-close-sub'}
                              onClick={() => {
                                window.childClose(i + 1, item.CategoryTitle);
                              }}
                            >
                              <i
                                className="fa fa-chevron-left"
                                aria-hidden="true"
                              >
                                {' '}
                                &nbsp; &nbsp;Back{' '}
                              </i>
                            </span>
                            <ul>{arrtempoptions}</ul>
                          </div>,
                        );

                        for (
                          let lastlevel = 0;
                          lastlevel < _arrOptionsNew.length;
                          lastlevel++
                        ) {
                          arrOptions.push(_arrOptionsNew[lastlevel]);
                        }
                      }
                    }
                  }
                }

                return arrOptions;
              })()
            ) : (
              <></>
            )}
          </div>
        </>
      );
    } else {
      return <></>;
    }
  }
}
export default MobileMenu;
