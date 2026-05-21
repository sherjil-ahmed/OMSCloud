import React from 'react';
import { FetchData } from '../../../utils/serviceHelper';
import {
  PROFILE_ID,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  APP_TOAST_POSITION,
  APP_ICONS,
  COLOR,
  GENERIC_VALIDATION_ERR_MSG,
} from '../../../utils/constants';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import moment from 'moment';
import izitoast from 'izitoast';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
const currentMonthDays = new Array(moment().daysInMonth())
  .fill(null)
  .map((x, i) => moment().startOf('month').add(i, 'days').format('DD'));
const months = [
  {
    id: '01',
    text: 'Jan',
    name: 'January',
  },
  {
    id: '02',
    text: 'Feb',
    name: 'Feburary',
  },
  {
    id: '03',
    text: 'Mar',
    name: 'March',
  },
  {
    id: '04',
    text: 'Apr',
    name: 'April',
  },
  {
    id: '05',
    text: 'May',
    name: 'May',
  },
  {
    id: '06',
    text: 'Jun',
    name: 'June',
  },
  {
    id: '07',
    text: 'Jul',
    name: 'July',
  },
  {
    id: '08',
    text: 'Aug',
    name: 'August',
  },
  {
    id: '09',
    text: 'Sep',
    name: 'September',
  },

  {
    id: '10',
    text: 'Oct',
    name: 'October',
  },

  {
    id: '11',
    text: 'Nov',
    name: 'November',
  },

  {
    id: '12',
    text: 'Dec',
    name: 'December',
  },
];
class ShopSettingSchedule extends React.Component {
  constructor(props) {
    super(props);
    this.resolve = null;
    this.ScheduleTypeID = null;
    this.ScheduleID = null;

    this.state = {
      currentMonthStart: moment().startOf('month'),
      arrShopAvailabilityDays: [],
      userProfile: props.shopData,
      Description: '',
    };
  }

  successGetScheduleByDates = (res) => {
    this.setState({
      arrShopAvailabilityDays: res,
    });
  };
  componentDidMount() {
    let fromDate = this.state.currentMonthStart.format('DD/MM/YYYY');
    let toDate = this.state.currentMonthStart
      .clone()
      .endOf('month')
      .format('DD/MM/YYYY');
    let supplierId =
      this.props && this.props.SupplierID
        ? this.props.SupplierID
        : getStorageItem(SUPPLIER_ID);
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Schedule_GetScheduleByDates +
        '?SupplierId=' +
        supplierId +
        '&FromDate=' +
        fromDate +
        '&ToDate=' +
        toDate,
      null,
      this.successGetScheduleByDates,
    );
    console.log('props',this.props)
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublic + 
        supplierId + '/' + getStorageItem(PROFILE_ID),
      null,
      this.gotSupplierDetails,
    );
  }

  gotSupplierDetails = (res) => {
    if (res != null) {
      console.log('shop calendar info',res)
      this.setState({
        Description : res.Description
      });
      //setStorageItem(SUPPLIER_ID, res.ShopID);
    }
  };

  changeMonth = (val) => {
    this.setState(
      { currentMonthStart: this.state.currentMonthStart.add('month', val) },
      () => {
        let fromDate = this.state.currentMonthStart.format('DD/MM/YYYY');
        let toDate = this.state.currentMonthStart
          .clone()
          .endOf('month')
          .format('DD/MM/YYYY');
        let supplierId =
          this.props && this.props.SupplierID
            ? this.props.SupplierID
            : getStorageItem(SUPPLIER_ID);
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Schedule_GetScheduleByDates +
            '?SupplierId=' +
            supplierId +
            '&FromDate=' +
            fromDate +
            '&ToDate=' +
            toDate,
          null,
          this.successGetScheduleByDates,
        );
      },
    );
  };

  render() {
    return (

      <div className="col-lg-8 order-lg-last dashboard-content" >
        <div className="body" >
          <div className="row rrvs">
            <div className="col-lg-8">
              <span style={{fontSize:'25px', fontWeight:'bolder'}}>Shop availability schedule</span>
              <table className="table-condensed table-bordered customtable">
                <thead>
                  <tr>
                    <th colSpan={7}>
                      <a
                        className="btn us-d"
                        onClick={(e) => {
                          e.preventDefault();
                          this.changeMonth(-1);
                        }}
                      >
                        <i className="icon-chevron-left" />
                      </a>
                      <a className="btn us-d">
                        {moment.months(this.state.currentMonthStart.month()) +
                          ' ' +
                          this.state.currentMonthStart.year()}
                      </a>
                      <a
                        className="btn us-d"
                        onClick={(e) => {
                          e.preventDefault();
                          this.changeMonth(1);
                        }}
                      >
                        <i className="icon-chevron-right" />
                      </a>
                    </th>
                  </tr>
                  <tr className="no_border_top">
                  <th>Mo</th>
                    <th>Tu</th>
                    <th>We</th>
                    <th>Th</th>
                    <th>Fr</th>
                    <th>Sa</th>
                    <th>Su</th>
                  </tr>
                </thead>
                <tbody>
                  {(() => {
                    let iterator = this.state.currentMonthStart.day();
                    if(iterator == 0) iterator = 6; else iterator = iterator-1;
                    //console.log(iterator, 'iterator');

                    let tempDateIterator = this.state.currentMonthStart.clone();
                    //console.log(tempDateIterator, 'tempDateIterator');
                    let tempDateIteratorNeg = this.state.currentMonthStart.clone();
                    let arrTR = [];
                    let flag = false;
                    for (let i = 0; i < 6; i++) {
                      let arrTD = [];
                      for (let j = 0; j < 7; j++) {
                        if (j < iterator && i == 0) 
                        {
                          //This part works when initial values are from past month. It will be visible on first row of calendar
                          tempDateIteratorNeg.add('day', -1 * (iterator - j));
                          arrTD.push(
                            <td className="muted">
                              {/*{tempDateIteratorNeg.format('DD')}*/}
                            </td>,
                          );
                          tempDateIteratorNeg = this.state.currentMonthStart.clone();
                        } 
                        else 
                        {
                          if (tempDateIterator.month() > this.state.currentMonthStart.month() 
                              ||
                              tempDateIterator.year() > this.state.currentMonthStart.year() 
                          ) 
                          {
                            //This part works when last values are from Next  month. It will be visible on Last row of calendar
                            arrTD.push(
                              <td className="muted">
                                {/*{tempDateIterator.format('DD')}*/}
                              </td>,
                            );
                          } 
                          else 
                          {
                            if (this.state.arrShopAvailabilityDays.includes(tempDateIterator.format('DD/MM/YYYY'),)) 
                            {
                              flag = true;
                              arrTD.push(
                                <td className="date_selected">
                                  {tempDateIterator.format('DD')}
                                </td>,
                              );
                            } 
                            else 
                            {
                              flag = true;
                              arrTD.push(
                                <td className="date_not_selected">{tempDateIterator.format('DD')}</td>,
                              );
                            }
                          }
                          tempDateIterator.add('day', 1);
                        }
                      }
                      console.log(flag, "flag");
                      if(flag === true){
                        arrTR.push(<tr>{arrTD}</tr>);
                      }
                      iterator = 0;
                      flag = false;
                    }
                    return arrTR;
                  })()}
                </tbody>
              </table>
              </div>
              <div className="col-lg-4">
              <span style={{fontSize:'25px', fontWeight:'bolder', color:'white'}}>*</span>
              <table className="table-condensed table-bordered customtable color-coding">
                <tbody>
                <tr>
                        <td className="date_not_selected" >Shop Closed</td>
                        
                        </tr>
                        <tr>
                          <td className="date_selected" >Shop Open</td>
                                          
                          </tr>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
      
    );
  }
}

export default ShopSettingSchedule;
