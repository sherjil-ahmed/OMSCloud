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
  SIZE
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
class ShopSchedule extends React.Component {
  constructor(props) {
    super(props);
    this.resolve = null;
    this.ScheduleTypeID = null;
    this.state = {
      isExceptionWeekly: '',
      isExceptionYearly: '',
      isExceptionMonthly: '',
      MonthlyFromDate: '00',
      MonthlyToDate: '00',
      SpecificDateMonth: '00',
      SpecificDateDay: '00',
      datesForSpecificMonth: [],
      Weekly: '',
      Monthly: '',
      Yearly: '',
      weekDays: [
        {
          dayName: 'Monday',
          day: 'Mon',
          isSelected: false,
        },
        {
          dayName: 'Tuesday',
          day: 'Tue',
          isSelected: false,
        },
        {
          dayName: 'Wednesday',
          day: 'Wed',
          isSelected: false,
        },
        {
          dayName: 'Thursday',
          day: 'Thu',
          isSelected: false,
        },
        {
          dayName: 'Friday',
          day: 'Fri',
          isSelected: false,
        },
        {
          dayName: 'Saturday',
          day: 'Sat',
          isSelected: false,
        },
        {
          dayName: 'Sunday',
          day: 'Sun',
          isSelected: false,
        },
      ],
      weeklyScheduleList: {
        Normal: [],
        Exp: [],
        ExpID: '',
        NormalID: '',
      },
      MonthlyScheduleList: [],
      YearlyScheduleList: [],
    };
  }

  handleWeekDays = (day) => {
    let weekDays = this.state.weekDays;
    let obj = weekDays.find((a) => a.day == day);
    obj.isSelected = obj.isSelected ? false : true;
    //weekDays.isSelected
    this.setState({ weekDays: weekDays });
  };

  handleChangeSpecificDateMonth = (e) => {
    this.setState({ SpecificDateMonth: e.target.value });
    let datesForSpecificMonth = new Array(
      moment(e.target.value, 'MM').daysInMonth(),
    )
      .fill(null)
      .map((x, i) => moment().startOf('month').add(i, 'days').format('DD'));
    this.setState({ datesForSpecificMonth: datesForSpecificMonth });
  };

  handleChangeSpecificDateDay = (e) => {
    this.setState({ SpecificDateDay: e.target.value }, () => {});
  };

  getWeekDayClass = (day) => {
    let weekDays = this.state.weekDays;
    let obj = weekDays.find((a) => a.day == day);
    return obj.isSelected ? 'days-tabs active-day' : 'days-tabs';
  };

  handleChangeCheckbox = (e) => {
    this.setState({
      [e.target.name]: e.target.checked,
    });
  };

  successGetScheduleInsert = (res) => {
    if (this.state.isExceptionWeekly) {
      _weeklyScheduleList.ExpID = res;
      _weeklyScheduleList.Exp = tempArr;
    } else {
      _weeklyScheduleList.NormalID = res;
      _weeklyScheduleList.Normal = tempArr;
    }

    this.resolve();
  };

  successGetSchedulePost = (res) => {
    if (this.state.isExceptionWeekly) {
      _weeklyScheduleList.ExpID = res;
      _weeklyScheduleList.Exp = tempArr;
    } else {
      _weeklyScheduleList.NormalID = res;
      _weeklyScheduleList.Normal = tempArr;
    }

    this.resolve();
  };

  successGetScheduleById = (res) => {
    reqObj.CreatedBy = res.CreatedBy;
    reqObj.CreatedOn = res.CreatedOn;
    reqObj.ModifiedBy = res.ModifiedBy;
    reqObj.ModifiedOn = res.ModifiedOn;

    //update
    //add concurrency model fields
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Schedule_Post,
      reqObj,
      this.successGetSchedulePost,
    );
  };

  AddWeeklySchedule = () => {
    let tempArr = this.state.weekDays
      .filter((a) => a.isSelected)
      .map((b) => b.day);
    let _weeklyScheduleList = this.state.weeklyScheduleList;
    let _weekDays = this.state.weekDays;
    let reqObj = {
      ShopID: getStorageItem(SUPPLIER_ID),
      StatusID: 1,
      ScheduleTypeID: 1,
      RequestedByProfileId: getStorageItem(PROFILE_ID),
      Notes: '',
      WeekDays: '',
      WeekDays: tempArr.toString(),
    };
    if (this.state.isExceptionWeekly) {
      reqObj.IsException = true;
      reqObj.ScheduleID = _weeklyScheduleList.ExpID;
    } else {
      _weeklyScheduleList.Normal = tempArr;
      reqObj.IsException = false;
      reqObj.ScheduleID = _weeklyScheduleList.NormalID;
    }

    let pSetState = new Promise((resolve, reject) => {
      this.resolve = resolve;
      if (reqObj.ScheduleID && reqObj.ScheduleID != '') {
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Schedule_GetScheduleById + reqObj.ScheduleID,
          null,
          this.successGetScheduleById,
        );
      } else {
        //insert
        FetchData(
          REQUEST_TYPE.PUT,
          SERVICE_ENDPOINTS.Schedule_Put,
          reqObj,
          this.successGetScheduleInsert,
        );
      }
    });

    pSetState.then(() => {
      _weekDays.forEach((o) => (o.isSelected = false));
      this.setState({
        weeklyScheduleList: _weeklyScheduleList,
        weekDays: _weekDays,
        isExceptionWeekly: false,
      });
    });
  };

  successMonthlyScheduleInsert = (res) => {
    let MonthlyArr = this.state.MonthlyScheduleList;
    let MonthlyTempArr = {
      FromDayofMonth: this.state.MonthlyFromDate,
      ToDayofMonth: this.state.MonthlyToDate,
      isExceptionMonthly: this.state.isExceptionMonthly,
    };

    MonthlyTempArr.ScheduleID = res;
    MonthlyArr.push(MonthlyTempArr);
    this.setState({
      MonthlyScheduleList: MonthlyArr,
      MonthlyFromDate: '00',
      MonthlyToDate: '00',
      isExceptionMonthly: false,
    });
  };

  AddMonthlySchedule = () => {
    if (
      this.state.FromDayofMonth !== '00' &&
      this.state.MonthlyToDate !== '00'
    ) {
      let reqObj = {
        FromDay: this.state.MonthlyFromDate,
        ToDay: this.state.MonthlyToDate,
        isException: this.state.isExceptionMonthly,
        ShopID: getStorageItem(SUPPLIER_ID),
        StatusID: 1,
        ScheduleTypeID: 2,
        RequestedByProfileId: getStorageItem(PROFILE_ID),
        Notes: '',
        WeekDays: '',
      };
      FetchData(
        REQUEST_TYPE.PUT,
        SERVICE_ENDPOINTS.Schedule_Put,
        reqObj,
        this.successMonthlyScheduleInsert,
      );
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: GENERIC_VALIDATION_ERR_MSG,
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  successYearlyScheduleInsert = (res) => {
    let tempArr = {
      SpecificDateMonth: this.state.SpecificDateMonth,
      SpecificDateDay: this.state.SpecificDateDay,
      isExceptionYearly: this.state.isExceptionYearly,
    };
    let YearlyArr = this.state.YearlyScheduleList;

    tempArr.ScheduleID = res;
    YearlyArr.push(tempArr);
    this.setState({
      YearlyScheduleList: YearlyArr,
      SpecificDateMonth: '00',
      SpecificDateDay: '00',
      isExceptionYearly: '',
    });
  };

  AddYearlySchedule = () => {
    if (
      this.state.SpecificDateMonth !== '00' &&
      this.state.SpecificDateDay !== '00'
    ) {
      let reqObj = {
        Month: this.state.SpecificDateMonth,
        MonthDay: this.state.SpecificDateDay,
        isException: this.state.isExceptionYearly,
        ShopID: getStorageItem(SUPPLIER_ID),
        StatusID: 1,
        ScheduleTypeID: 3,
        RequestedByProfileId: getStorageItem(PROFILE_ID),
        Notes: '',
        WeekDays: '',
      };
      FetchData(
        REQUEST_TYPE.PUT,
        SERVICE_ENDPOINTS.Schedule_Put,
        reqObj,
        this.successYearlyScheduleInsert,
      );
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: GENERIC_VALIDATION_ERR_MSG,
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  successRemoveSchedule = (res) => {
    if (this.ScheduleTypeID == '1') {
      //Weekly
    } else if (this.ScheduleTypeID == '2') {
      //Monthly
      let _MonthlyScheduleList = this.state.MonthlyScheduleList;
      _MonthlyScheduleList = _MonthlyScheduleList.filter(
        (a) => !(a.ScheduleID == ScheduleID),
      );
      this.setState({
        MonthlyScheduleList: _MonthlyScheduleList,
      });
    } else if (this.ScheduleTypeID == '3') {
      //Yearly
      let _YearlyScheduleList = this.state.YearlyScheduleList;
      _YearlyScheduleList = _YearlyScheduleList.filter(
        (a) => !(a.ScheduleID == ScheduleID),
      );
      this.setState({
        YearlyScheduleList: _YearlyScheduleList,
      });
    }
  };

  RemoveSelectedSchedule = (ScheduleTypeID, ScheduleID) => {
    this.ScheduleTypeID = ScheduleTypeID;
    FetchData(
      REQUEST_TYPE.DELETE,
      SERVICE_ENDPOINTS.Schedule_Delete + ScheduleID,
      null,
      this.successRemoveSchedule,
    );
  };

  successGetScheduleBySupplierId = (res) => {
    let GetScheduleList = JSON.parse(JSON.stringify(res));
    if (GetScheduleList.length > 0) {
      for (let item of GetScheduleList) {
        if (item.ScheduleTypeID === 1) {
          let _weeklyScheduleList = this.state.weeklyScheduleList;
          if (item.IsException) {
            _weeklyScheduleList.Exp = item.WeekDays.split(',');
            _weeklyScheduleList.ExpID = item.ScheduleID;
            //concurrency
            _weeklyScheduleList.ECreatedBy = item.CreatedBy;
            _weeklyScheduleList.ECreatedOn = item.CreatedOn;
            _weeklyScheduleList.EModifiedBy = item.ModifiedBy;
            _weeklyScheduleList.EModifiedOn = item.ModifiedOn;
          } else {
            _weeklyScheduleList.Normal = item.WeekDays.split(',');
            _weeklyScheduleList.NormalID = item.ScheduleID;
            //concurrency
            _weeklyScheduleList.NCreatedBy = item.CreatedBy;
            _weeklyScheduleList.NCreatedOn = item.CreatedOn;
            _weeklyScheduleList.NModifiedBy = item.ModifiedBy;
            _weeklyScheduleList.NModifiedOn = item.ModifiedOn;
          }
          this.setState({
            weeklyScheduleList: _weeklyScheduleList,
          });
        } else if (item.ScheduleTypeID === 2) {
          let _monthlyScheduleList = this.state.MonthlyScheduleList;
          let temp = {
            FromDayofMonth: item.FromDay,
            ToDayofMonth: item.ToDay,
            isExceptionMonthly: item.IsException,
            ScheduleID: item.ScheduleID,
          };
          _monthlyScheduleList.push(temp);
          this.setState({ MonthlyScheduleList: _monthlyScheduleList });
        } else if (item.ScheduleTypeID === 3) {
          let _yearlyScheduleList = this.state.YearlyScheduleList;
          let temp1 = {
            SpecificDateMonth: item.Month,
            SpecificDateDay: item.MonthDay,
            isExceptionYearly: item.IsException,
            ScheduleID: item.ScheduleID,
          };
          _yearlyScheduleList.push(temp1);
          this.setState({ YearlyScheduleList: _yearlyScheduleList });
        }
      }
    }
  };

  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Schedule_GetScheduleListBySupplierId +
        getStorageItem(SUPPLIER_ID),
      null,
      this.successGetScheduleBySupplierId,
    );
  }

  render() {
    // let _state = this.props.parentState.Supplier;
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Shop Schedule</title>
        </Helmet>
        <Header />
        <main className="main">
          <nav aria-label="breadcrumb" className="breadcrumb-nav">
            <div className="container">
              <ol className="breadcrumb">
                <li className="breadcrumb-item">
                  <a href="/">
                    <i className="icon-home" />
                  </a>
                </li>
                <li className="breadcrumb-item active" aria-current="page">
                  Shop Schedule
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          <div className="container">
            <div className="mainsliwrapper">
              <div className="heading">
                <div className="row">
                  <div className="col-md-6 col-sm-12">
                    <h2 className="title">Shop Delivery Schedule</h2>
                  </div>
                </div>
              </div>
              <div className="body">
                <div className="row marbtm">
                  <div className="col-sm-12 npad">
                    <div className="row justify-content-center">
                      <div className="col-md-5">
                        <div className="form-group">
                          <ul className="ks-cboxtags">
                            <li>
                              <input
                                type="checkbox"
                                id="Weekly"
                                name="Weekly"
                                onChange={this.handleChangeCheckbox}
                              />
                              <label htmlFor="Weekly" className="npad" />
                              <span className="label span">
                                Weekly Schedule
                              </span>
                            </li>
                          </ul>
                        </div>
                      </div>
                      {/*End Form Col-1*/}
                      <div className="col-md-5">
                        <div className="form-group">
                          <ul className="ks-cboxtags">
                            <li>
                              <input
                                type="checkbox"
                                id="isExceptionWeekly"
                                name="isExceptionWeekly"
                                checked={this.state.isExceptionWeekly}
                                onChange={this.handleChangeCheckbox}
                              />
                              <label
                                htmlFor="isExceptionWeekly"
                                className="npad"
                              />
                              <span className="label span">Exception</span>
                            </li>
                          </ul>
                        </div>
                      </div>
                      {/*End Form Col-2*/}
                      <div className="col-md-2 att-btn-col toppadding"></div>
                      {/*End Form Col-3*/}
                    </div>
                    <div className="row justify-content-center">
                      <div className="col-md-10">
                        <ul className="col weekly-tabs">
                          <li
                            onClick={() => {
                              this.handleWeekDays('Mon');
                            }}
                          >
                            <p className={this.getWeekDayClass('Mon')}>
                              Monday
                            </p>
                          </li>
                          <li
                            onClick={() => {
                              this.handleWeekDays('Tue');
                            }}
                          >
                            <p className={this.getWeekDayClass('Tue')}>
                              Tuesday
                            </p>
                          </li>
                          <li
                            onClick={() => {
                              this.handleWeekDays('Wed');
                            }}
                          >
                            <p className={this.getWeekDayClass('Wed')}>
                              Wednesday
                            </p>
                          </li>
                          <li
                            onClick={() => {
                              this.handleWeekDays('Thu');
                            }}
                          >
                            <p className={this.getWeekDayClass('Thu')}>
                              Thursday
                            </p>
                          </li>
                          <li
                            onClick={() => {
                              this.handleWeekDays('Fri');
                            }}
                          >
                            <p className={this.getWeekDayClass('Fri')}>
                              Friday
                            </p>
                          </li>
                          <li
                            onClick={() => {
                              this.handleWeekDays('Sat');
                            }}
                          >
                            <p className={this.getWeekDayClass('Sat')}>
                              Saturday
                            </p>
                          </li>
                          <li
                            onClick={() => {
                              this.handleWeekDays('Sun');
                            }}
                          >
                            <p className={this.getWeekDayClass('Sun')}>
                              Sunday
                            </p>
                          </li>
                        </ul>
                      </div>
                      {/*End Form Col-1*/}
                      <div className="col-md-2 att-btn-col">
                        <button
                          type="button"
                          className="btn btn-outline-dark custom-btn prebtn"
                          onClick={this.AddWeeklySchedule}
                        >
                          Add Schedule
                        </button>
                      </div>
                      {/*End Form Col-3*/}
                    </div>
                    <br />
                    <div className="row">
                      <div className="col-sm-12">
                        <table className="table text-center weektable">
                          <thead className="thead-light">
                            <tr>
                              <th scope="col">Is Exception</th>
                              {this.state.weekDays.map((a, i) => (
                                <th key={i} scope="col">
                                  {a.day}
                                </th>
                              ))}
                            </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <th scope="row">Yes</th>
                              {(() => {
                                let renderObj = [];
                                let i = 0;
                                for (let x of this.state.weekDays) {
                                  let y = this.state.weeklyScheduleList.Exp.find(
                                    (a) => a == x.day,
                                  );
                                  if (y) {
                                    i++;
                                    renderObj.push(
                                      <td key={i} className="yesex" />,
                                    );
                                  } else {
                                    i++;
                                    renderObj.push(<td key={i} />);
                                  }
                                }
                                return renderObj;
                              })()}
                            </tr>
                            <tr>
                              <th scope="row">No</th>
                              {(() => {
                                let renderObj = [];
                                let i = 0;
                                for (let x of this.state.weekDays) {
                                  let y = this.state.weeklyScheduleList.Normal.find(
                                    (a) => a == x.day,
                                  );

                                  if (y) {
                                    i++;
                                    renderObj.push(
                                      <td key={i} className="noex" />,
                                    );
                                  } else {
                                    i++;
                                    renderObj.push(<td key={i} />);
                                  }
                                }

                                return renderObj;
                              })()}
                            </tr>
                          </tbody>
                        </table>
                      </div>
                    </div>
                  </div>
                  {/* End .row */}
                </div>
                <div className="row marbtm">
                  <div className="col-sm-12 npad">
                    <div className="row justify-content-center">
                      <div className="col-md-5">
                        <div className="form-group">
                          <ul className="ks-cboxtags">
                            <li>
                              <input
                                type="checkbox"
                                id="Monthly"
                                name="Monthly"
                                onChange={this.handleChangeCheckbox}
                              />
                              <label htmlFor="Monthly" className="npad" />
                              <span className="label span">
                                Monthly Schedule
                              </span>
                            </li>
                          </ul>
                          <div className="select-custom">
                            <select
                              className="form-control"
                              name="MonthlyFromDate"
                              onChange={(e) => {
                                this.setState({
                                  MonthlyFromDate: e.target.value,
                                });
                              }}
                              value={this.state.MonthlyFromDate}
                            >
                              <option value="00">Select from Day</option>
                              {currentMonthDays.map((a, i) => (
                                <option key={i} value={a}>
                                  {a}
                                </option>
                              ))}
                            </select>
                          </div>
                          {/* End .select-custom */}
                        </div>
                      </div>
                      {/*End Form Col-1*/}
                      <div className="col-md-5">
                        <div className="form-group">
                          <ul className="ks-cboxtags">
                            <li>
                              <input
                                type="checkbox"
                                id="isExceptionMonthly"
                                checked={this.state.isExceptionMonthly}
                                name="isExceptionMonthly"
                                onChange={this.handleChangeCheckbox}
                              />
                              <label
                                htmlFor="isExceptionMonthly"
                                className="npad"
                              />
                              <span className="label span">Exception</span>
                            </li>
                          </ul>
                          <div className="select-custom">
                            <select
                              className="form-control"
                              name="MonthlyToDate"
                              onChange={(e) => {
                                this.setState({
                                  MonthlyToDate: e.target.value,
                                });
                              }}
                              value={this.state.MonthlyToDate}
                            >
                              <option value="00">Select to Day</option>
                              {currentMonthDays.map((a, i) => {
                                if (
                                  parseInt(a) >
                                  parseInt(this.state.MonthlyFromDate)
                                ) {
                                  return (
                                    <option key={i} value={a}>
                                      {a}
                                    </option>
                                  );
                                }
                              })}
                            </select>
                          </div>
                          {/* End .select-custom */}
                        </div>
                      </div>
                      {/*End Form Col-2*/}
                      <div className="col-md-2 att-btn-col toppadding">
                        <button
                          type="button"
                          className="btn btn-outline-dark custom-btn prebtn"
                          onClick={this.AddMonthlySchedule}
                        >
                          Add Schedule
                        </button>
                      </div>
                      {/*End Form Col-3*/}
                    </div>
                    <br />
                    <div className="row">
                      <div className="col-sm-12">
                        <table className="table text-center">
                          <thead className="thead-light">
                            <tr>
                              <th scope="col">#</th>
                              <th scope="col">"From" Day of Month</th>
                              <th scope="col">"To" Day of Month</th>
                              <th scope="col">Action</th>
                              <th scope="col">Is Exception</th>
                            </tr>
                          </thead>
                          <tbody>
                            {(() => {
                              let i = 1;
                              let renderObj = [];
                              for (let item of this.state.MonthlyScheduleList) {
                                renderObj.push(
                                  <tr key={i}>
                                    <th scope="row">{i}</th>
                                    <td>{item.FromDayofMonth}</td>
                                    <td>{item.ToDayofMonth}</td>
                                    <td
                                      onClick={() => {
                                        this.RemoveSelectedSchedule(
                                          '2',
                                          item.ScheduleID,
                                        );
                                      }}
                                    >
                                      x
                                    </td>
                                    <td>
                                      <label
                                        className="checkbox-label form-check-label"
                                        htmlFor={'check-' + i}
                                      >
                                        <input
                                          type="checkbox"
                                          checked={item.isExceptionMonthly}
                                          className="form-check-input"
                                          id={'check-' + i}
                                          onChange={(e) => {}}
                                        />
                                        <span className="checkbox-custom circular" />
                                      </label>
                                    </td>
                                  </tr>,
                                );
                                i++;
                              }
                              return renderObj;
                            })()}
                          </tbody>
                        </table>
                      </div>
                    </div>
                  </div>
                  {/* End .row */}
                </div>
                <div className="row marbtm">
                  <div className="col-sm-12 npad">
                    <div className="row justify-content-center">
                      <div className="col-md-5">
                        <div className="form-group">
                          <ul className="ks-cboxtags">
                            <li>
                              <input
                                type="checkbox"
                                id="Yearly"
                                name="Yearly"
                                onChange={this.handleChangeCheckbox}
                              />
                              <label htmlFor="Yearly" className="npad" />
                              <span className="label span">Specific Dates</span>
                            </li>
                          </ul>
                          <div className="select-custom">
                            <select
                              className="form-control"
                              name="SpecificDateMonth"
                              onChange={(e) =>
                                this.handleChangeSpecificDateMonth(e)
                              }
                              value={this.state.SpecificDateMonth}
                            >
                              <option value="00">Select a Month</option>
                              {months.map((a, i) => (
                                <option key={i} value={a.id}>
                                  {a.name}
                                </option>
                              ))}
                            </select>
                          </div>
                          {/* End .select-custom */}
                        </div>
                      </div>
                      {/*End Form Col-1*/}
                      <div className="col-md-5">
                        <div className="form-group">
                          <ul className="ks-cboxtags">
                            <li>
                              <input
                                type="checkbox"
                                id="isExceptionYearly"
                                name="isExceptionYearly"
                                checked={this.state.isExceptionYearly}
                                onChange={this.handleChangeCheckbox}
                              />
                              <label
                                htmlFor="isExceptionYearly"
                                className="npad"
                              />
                              <span className="label span">Exception</span>
                            </li>
                          </ul>
                          <div className="select-custom">
                            <select
                              name="SpecificDateDay"
                              className="form-control"
                              onChange={(e) =>
                                this.handleChangeSpecificDateDay(e)
                              }
                              value={this.state.SpecificDateDay}
                            >
                              <option value="00">Select to Day</option>
                              {this.state.datesForSpecificMonth.map((a, i) => (
                                <option key={i} value={a}>
                                  {a}
                                </option>
                              ))}
                            </select>
                          </div>
                          {/* End .select-custom */}
                        </div>
                      </div>
                      {/*End Form Col-2*/}
                      <div className="col-md-2 att-btn-col toppadding">
                        <button
                          type="button"
                          className="btn btn-outline-dark custom-btn prebtn"
                          onClick={this.AddYearlySchedule}
                        >
                          Add Schedule
                        </button>
                      </div>
                      {/*End Form Col-3*/}
                    </div>
                    <br />
                    <div className="row">
                      <div className="col-sm-12">
                        <table className="table text-center">
                          <thead className="thead-light">
                            <tr>
                              <th scope="col">#</th>
                              <th scope="col">Selected Date Month / Day</th>
                              <th scope="col">Action</th>
                              <th scope="col">Is Exception</th>
                            </tr>
                          </thead>
                          <tbody>
                            {(() => {
                              let i = 1;
                              let renderObj = [];
                              for (let item of this.state.YearlyScheduleList) {
                                renderObj.push(
                                  <tr key={i}>
                                    <th scope="row">{i}</th>
                                    <td>
                                      {item.SpecificDateMonth +
                                        '/' +
                                        item.SpecificDateDay}
                                    </td>
                                    <td
                                      onClick={() => {
                                        this.RemoveSelectedSchedule(
                                          '3',
                                          item.ScheduleID,
                                        );
                                      }}
                                    >
                                      x
                                    </td>
                                    <td>
                                      <label
                                        className="checkbox-label form-check-label"
                                        htmlFor={'checkY-' + i}
                                      >
                                        <input
                                          type="checkbox"
                                          className="form-check-input"
                                          checked={item.isExceptionYearly}
                                          id={'checkY-' + i}
                                          onChange={(e) => {}}
                                        />
                                        <span className="checkbox-custom circular" />
                                      </label>
                                    </td>
                                  </tr>,
                                );
                                i++;
                              }
                              return renderObj;
                            })()}
                          </tbody>
                        </table>
                      </div>
                    </div>
                  </div>
                  {/* End .row */}
                </div>
              </div>
            </div>
            <div className="mb-10" />
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default ShopSchedule;
