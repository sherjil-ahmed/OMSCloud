import React from 'react';
import { NotificationTypes, SubjectID,ProductnShopStatus } from '../../../utils/enums';
import { REQUEST_TYPE, SERVICE_ENDPOINTS } from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import SearchItem from '../../customControls/SearchList/searchItem';
import Pagination from '../../customControls/Pagination/pagination';
import moment from 'moment';

const DISPLAY_PAGES = 10;
class Reviews extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      currPage: 1,
      reviewList: {},
      masterReviewList: {},
      colOrder: {},
    };
  }
  componentDidMount() {
    let userInfo = this.props.parentData;
    console.log("PROPS",this.props)
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.CustomerReview_GetCustomerReviewList +
        '?authorId=' +
        userInfo.ProfileID,
      null,
      this.successGetNotificationsList,
    );
  }
  successGetNotificationsList = (res) => {
    this.setState({
      reviewList: res,
      masterReviewList: res,
    });
  };
  updatereviewList = (res) => {
    this.setState({
      reviewList: res,
      currPage: 1,
    });
  };
  sortTable = (prop) => {
    let order = this.state.colOrder[prop];
    if (order && order == 'asc') {
      this.state.colOrder[prop] = 'desc';
      this.state.reviewList.sort((a, b) => {
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
      this.state.reviewList.sort((a, b) => {
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
      reviewList: this.state.reviewList,
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
          parentData={this.state.masterReviewList}
          updateList={this.updatereviewList}
          criteria={['CreatedOn','ReviewText']}
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
              <th>Review</th>
              <th
                className="cursorpointer"
                onClick={() => {
                  this.sortTable('SubjectID', '');
                }}
              >
                Review For &nbsp;
                {this.state.colOrder['SubjectID'] ? (
                  this.state.colOrder['SubjectID'] === 'asc' ? (
                    <i className="fa fa-long-arrow-up" aria-hidden="true"></i>
                  ) : (
                    <i className="fa fa-long-arrow-down" aria-hidden="true"></i>
                  )
                ) : (
                  <></>
                )}
              </th>
              <th
                className="cursorpointer"
                onClick={() => {
                  this.sortTable('StatusID', '');
                }}
              >
                Status &nbsp;
                {this.state.colOrder['StatusID'] ? (
                  this.state.colOrder['StatusID'] === 'asc' ? (
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
              this.state.reviewList && this.state.reviewList.length > 0 ? (
                (() => {
                  let returnArr = [];
                  let startIdx = (this.state.currPage - 1) * DISPLAY_PAGES;
                  let endIdx =
                    this.state.currPage * DISPLAY_PAGES >
                    this.state.reviewList.length
                      ? this.state.reviewList.length
                      : this.state.currPage * DISPLAY_PAGES;
                  for (let index = startIdx; index < endIdx; index++) {
                    let item = this.state.reviewList[index];
                    returnArr.push(
                      <tr key={index}>
                        <td>
                          {moment(item.CreatedOn).format('DD/MM/YYYY hh:mm:ss')}
                        </td>
                        <td>{item.ReviewText}</td>
                        <td>
                        {SubjectID[item.SubjectID]
                          }
                        </td>
                        <td>
                        {Object.keys(ProductnShopStatus).find(
                          (key) => ProductnShopStatus[key] === item.StatusID)}
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
          totalRecords={this.state.reviewList.length}
          DISPLAY_PAGES={DISPLAY_PAGES}
          setCurrentPage={this.setCurrentPage}
        />
      </div>
    );
  }
}
export default Reviews;
