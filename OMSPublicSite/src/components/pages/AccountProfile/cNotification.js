import React from 'react';
import { NotificationTypes } from '../../../utils/enums';
import { REQUEST_TYPE, SERVICE_ENDPOINTS } from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import SearchItem from '../../customControls/SearchList/searchItem';
import Pagination from '../../customControls/Pagination/pagination';
import moment from 'moment';

const DISPLAY_PAGES = 10;
class Notifications extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      currPage: 1,
      notificationList: {},
      masterNotificationList: {},
      colOrder: {},
    };
  }
  componentDidMount() {
    let userInfo = this.props.parentData;
    let ReceiverId = userInfo.ProfileID;
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Notification_GetNotifyList +
        '?ReceiverId=' +
        ReceiverId +
        '&NotificationType=',
      null,
      this.successGetNotificationsList,
    );
  }
  successGetNotificationsList = (res) => {
    this.setState({
      notificationList: res,
      masterNotificationList: res,
    });
  };
  updateNotificationList = (res) => {
    this.setState({
      notificationList: res,
      currPage: 1,
    });
  };
  sortTable = (prop) => {
    let order = this.state.colOrder[prop];
    if (order && order == 'asc') {
      this.state.colOrder[prop] = 'desc';
      this.state.notificationList.sort((a, b) => {
        if (a[prop] < b[prop]) {
          return -1;
        }
        if (a[prop] > b[prop]) {
          return 1;
        }
        return 0;
      });
    } else {
      this.state.colOrder[prop] = 'asc';
      this.state.notificationList.sort((a, b) => {
        if (a[prop] < b[prop]) {
          return 1;
        }
        if (a[prop] > b[prop]) {
          return -1;
        }
        return 0;
      });
    }
    this.setState({
      colOrder: this.state.colOrder,
      notificationList: this.state.notificationList,
    });
  };
  setCurrentPage = (pgnum) => {
    this.setState({
      currPage: pgnum,
    });
  };
  render() {
    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        <SearchItem
          parentData={this.state.masterNotificationList}
          updateList={this.updateNotificationList}
          criteria={['CreatedOn', 'Message', 'NotificationType']}
        />
        <table
          className="table table-striped"
          style={{
            borderWidth: '1px',
            borderColor: '#aaaaaa',
            borderStyle: 'solid',
          }}
        >
          <thead>
            <tr>
              <th
                className="cursorpointer"
                onClick={() => {
                  this.sortTable('CreatedOn', '');
                }}
              >
                Created On &nbsp;
                {this.state.colOrder['CreatedOn'] ? (
                  this.state.colOrder['CreatedOn'] === 'asc' ? (
                    <i className="fa fa-long-arrow-up" aria-hidden="true"></i>
                  ) : (
                    <i className="fa fa-long-arrow-down" aria-hidden="true"></i>
                  )
                ) : (
                  <></>
                )}
              </th>
              <th>Message</th>
              <th
                className="cursorpointer"
                onClick={() => {
                  this.sortTable('NotificationType', '');
                }}
              >
                Notification Type &nbsp;
                {this.state.colOrder['NotificationType'] ? (
                  this.state.colOrder['NotificationType'] === 'asc' ? (
                    <i className="fa fa-long-arrow-up" aria-hidden="true"></i>
                  ) : (
                    <i className="fa fa-long-arrow-down" aria-hidden="true"></i>
                  )
                ) : (
                  <></>
                )}
              </th>
            </tr>
          </thead>
          <tbody>
            {
              this.state.notificationList &&
              this.state.notificationList.length > 0 ? (
                (() => {
                  let returnArr = [];
                  let startIdx = (this.state.currPage - 1) * DISPLAY_PAGES;
                  let endIdx =
                    this.state.currPage * DISPLAY_PAGES >
                    this.state.notificationList.length
                      ? this.state.notificationList.length
                      : this.state.currPage * DISPLAY_PAGES;
                  for (let index = startIdx; index < endIdx; index++) {
                    let item = this.state.notificationList[index];
                    returnArr.push(
                      <tr key={index}>
                        <td>
                          {moment(item.CreatedOn).format('DD/MM/YYYY hh:mm:ss')}
                        </td>
                        <td>{item.Message}</td>
                        <td>
                          {Object.keys(NotificationTypes).find(
                            (key) =>
                              NotificationTypes[key] === item.NotificationType,
                          )}
                        </td>
                      </tr>,
                    );
                  }
                  return returnArr;
                })()
              ) : (
                <></>
              )
              // data.map((item, index) =>
              //     )
            }
          </tbody>
        </table>
        <Pagination
          currPage={this.state.currPage}
          totalRecords={this.state.notificationList.length}
          DISPLAY_PAGES={DISPLAY_PAGES}
          setCurrentPage={this.setCurrentPage}
        />
      </div>
    );
  }
}
export default Notifications;
