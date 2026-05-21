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
  } from '../utils/constants';  
import { baseUrlImage, FetchData } from '../utils/serviceHelper';
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
    this.setState({
      bodyClassList: window.document.body.classList,
    },()=>{
        window.bindMobmenuOptions()
    });
  };

  render() {
    if (this.state.bodyClassList.contains('mmenu-active')) {
      console.log("IN FUNC")
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
        <div id="mySidebar" className="sidebar">
          <a
            href=""
            className="closebtn"
            onClick={(e) => {
              e.preventDefault();
              window.document.body.classList.remove('mmenu-active');
              this.updateMobileMenu();
            }}
          >
              ×
          </a>
          {mainCategories && mainCategories.length > 0 ? (
                  (() => {
                    let arrOptions = [];

                    for (let i = 0; i < mainCategories.length; i++) {
                      if (i >= 7) {
                        break;
                      }

                      let item = mainCategories[i];
                      if(item.IsSystem === true && item.CategoryTypeID===1){
                        let option = (
                            <>
							<a href="#" className= {sublvl1Categories &&
									sublvl1Categories.length > 0 ? "side-a click-to-expand" : ""}>
								{item.CategoryTitle}             
                            </a>
							<div className="mobile-inner-dropdown expand hidden">
								{sublvl1Categories &&
									sublvl1Categories.length > 0 ? (
									  sublvl1Categories
										.filter(
										  (f) =>
											f.CategoryParentID == item.CategoryID,
										)
										.map((slvl1item, j) => (
                                            <>
                                            <div className="mob-in-sub">
                                                <a href={
                                                        '/search?' +
                                                        `CategoryID=${slvl1item.CategoryID}&openFilter=${this.state.openFilter}`
                                                        } className="f-p-c">
                                                    {slvl1item.CategoryTitle}
                                                </a>
                                                {sublvl2Categories &&
                                                sublvl2Categories.length > 0 
                                                ?
                                                    <span className= "sub-in-icon" >
                                                        <i className= {sublvl2Categories.find((f) =>f.CategoryParentID == slvl1item.CategoryID) ?
                                                        "fa fa-angle-down click-to-expand" : "fa fa-angle-down click-to-expand custom-mob-menu"}
                                                         aria-hidden="true">
                                                        </i>
                                                    </span> : <></>}
                                            </div>
                                            
											{/* <a href={
													'/search?' +
													`CategoryID=${slvl1item.CategoryID}&openFilter=${this.state.openFilter}`
												  } className= {sublvl2Categories &&
                                                    sublvl2Categories.length > 0 ? "side-a click-to-expand" : ""}>
											   {slvl1item.CategoryTitle}
											</a> */}
											<div className="mobile-inner-dropdown expand hidden">
											  {sublvl2Categories &&
											  sublvl2Categories.length > 0 ? (
												sublvl2Categories
												  .filter(
													(f) =>
													  f.CategoryParentID ==
													  slvl1item.CategoryID,
												  )
												  .map((slvl2item, k) => (
                                                    <>
                                                    <div className="mob-in-sub">
                                                        <a href={
														                            '/search?' +`CategoryID=${slvl2item.CategoryID}&openFilter=${this.state.openFilter}`														  
                                                        } className="f-p-c">
                                                            {slvl2item.CategoryTitle}   
                                                        </a>
                                                    {sublvl3Categories &&
                                                    sublvl3Categories.length > 0  
                                                    // && sublvl3Categories.find((f) =>f.CategoryParentID == slvl2item.CategoryID)
                                                    ?
                                                        <span className= "sub-in-icon">
                                                            <i className= { sublvl3Categories.find((f) =>f.CategoryParentID == slvl2item.CategoryID) ? 
                                                            "fa fa-angle-down click-to-expand": "fa fa-angle-down click-to-expand custom-mob-menu"} 
                                                            aria-hidden="true">
                                                            </i>
                                                        </span> : <></>}
                                                    </div> 
                                                        
                                                    
													  {/* <a 
														href={
														  '/search?' +`CategoryID=${slvl2item.CategoryID}&openFilter=${this.state.openFilter}`														  
                                                        }
                                                        class= {sublvl3Categories && sublvl3Categories.length > 0 ? 
                                                                "side-a click-to-expand hidden" : ""}
													  >
                                                          {slvl2item.CategoryTitle}
													  </a> */}
                                                      {sublvl3Categories &&
														sublvl3Categories.length >
														  0 ? (
														  sublvl3Categories
															.filter(
															  (f) =>
																f.CategoryParentID ==
																slvl2item.CategoryID,
															)
															.map((slvl3item, l) => (
																<a
																  href={
																	'/search?' +
																	`CategoryID=${slvl3item.CategoryID}&openFilter=${this.state.openFilter}`
																  }
																>
																  {slvl3item.CategoryTitle}
																</a>
															))
														) : (
														  <></>
														)}
												  </>))
											  ) : (
												<></>
											  )}
											</div>
                                            </>
										))
									) : (
									  <></>
									)}	
							 </div>
							</> 
                             );
								arrOptions.push(option);}
							 }
							 return arrOptions;
							  })()
							) : (
							  <></>
							)}
          </div>
      );
    } else {
      return <></>;
    }
    }
}
export default MobileMenu;
