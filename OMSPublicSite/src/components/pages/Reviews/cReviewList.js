import React from 'react';
import { Helmet } from 'react-helmet';
import { REQUEST_TYPE, SERVICE_ENDPOINTS } from '../../../utils/constants';
import { FetchData, baseUrlImage, baseUrl } from '../../../utils/serviceHelper';
import moment from 'moment';
import { ImageEntityEnum, ReviewScaleText } from '../../../utils/enums';
import Pagination from '../../customControls/Pagination/pagination';

const DISPLAY_PAGES = 10;
const Comment = (props) => (
  <div className="comment">
    <img
      src={
        baseUrlImage +
        ImageEntityEnum.USER +
        '/' +
        props.customerID +
        '/' +
        props.userPic
      }
      className="commentPic"
      alt="user Pic"
    />
    <div className="commentBody">
      <div className="commentHeader">
        <h3 className="commentAuthor">{props.user}</h3>
        <span className="publishDate">{props.publishDate}</span>
        <div className="ratings-container ml-4 mt-1">
          <div className="product-ratings">
            <span
              className="ratings"
              style={{ width: '' + parseFloat(props.rating / 5) * 100 + '%' }}
            />
            {/* <span className="ml-2">{props.rating ? ReviewScaleText[props.rating] : ""}</span> */}
          </div>
        </div>
      </div>

      <span className="commentContent">{props.content}</span>
    </div>
  </div>
);

class ReviewList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      currPage: 1,
      comments: [],
    };
  }

  successGetCustomerReviewList = (res) => {
    console.log('resofreviews', res)
    let _comments = [];
    for (let item of res) {
      item.ago = moment(item.CreatedOn).fromNow();
      let comment = {
        id: item.CustomerReviewID,
        user: item.ReviewerName,
        content: item.ReviewText,
        userPic: item.ReviewerImage,
        publishDate: item.ago,
        rating: item.Rating,
        customerReviewID: item.CreatedBy,
      };
      _comments.push(comment);
    }
    this.setState({
      comments: _comments,
    });
  };

  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.CustomerReview_GetCustomerReviewList +
        '?authorId=' +
        '' +
        '&subject=' +
        this.props.type.value +
        '&SubjectRowId=' +
        this.props.id +
        '&statusId=' +
        2,
      null,
      this.successGetCustomerReviewList,
    );
  }
  setCurrentPage = (pgnum) => {
    this.setState({
      currPage: pgnum,
    });
  };

  render() {
    return (
      <div>
        <Helmet>
          <link rel="stylesheet" href="assets/css/woocommerce-review.css" />
        </Helmet>
        {
          (() => {
            let returnArr = [];
            let startIdx = (this.state.currPage - 1) * DISPLAY_PAGES;
            let endIdx =
              this.state.currPage * DISPLAY_PAGES > this.state.comments.length
                ? this.state.comments.length
                : this.state.currPage * DISPLAY_PAGES;
            for (let index = startIdx; index < endIdx; index++) {
              let item = this.state.comments[index];
              returnArr.push(
                <Comment
                  publishDate={item.publishDate}
                  key={item.id}
                  id={item.id}
                  content={item.content}
                  customerID={item.customerReviewID}
                  user={item.user}
                  userPic={item.userPic}
                  rating={item.rating}
                />,
              );
            }
            return returnArr;
          })()
          // this.state.comments.map((comment)=>
          // <Comment
          //     publishDate={comment.publishDate}
          //     key={comment.id}
          //     id={comment.id}
          //     content={comment.content}
          //     customerID ={comment.customerReviewID}
          //     user={comment.user}
          //     userPic={comment.userPic}
          //     rating={comment.rating}/>
          // )
        }
        <Pagination
          currPage={this.state.currPage}
          totalRecords={this.state.comments.length}
          DISPLAY_PAGES={DISPLAY_PAGES}
          setCurrentPage={this.setCurrentPage}
        />
      </div>
    );
  }
}

export default ReviewList;
