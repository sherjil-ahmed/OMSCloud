import React from 'react';
import { getStorageItem } from '../../../utils/storageHelper';
import izitoast from 'izitoast';
import {
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  PROFILE_ID,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SIZE
} from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';

class CreateReview extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      rating: '',
      review: '',
    };
  }

  componentDidMount() {}

  successSaveReview = (res) => {
          izitoast.destroy();
      izitoast.show({

      title: '',
      icon: APP_ICONS.SUCCESS,
      message: 'Your review has been successfully submitted.',
      //position : APP_TOAST_POSITION.BOTTOM_CENTER,
      target: '.testtarget',
      color: COLOR.GREEN,
      messageSize: SIZE.FONT_SIZE
    });

    this.setState({
      rating: '',
      review: '',
    });
  };

  handleSubmit = (e) => {
    
    let reqData = {
      SubjectID: this.props.type.value,
      SubjectRowID: this.props.id,
      ReviewText: this.state.review,
      Rating: this.state.rating,
      StatusID: '1',
      RequestedByProfileId: getStorageItem(PROFILE_ID),
    };

    if (this.state.rating && this.state.review) {
      FetchData(
        REQUEST_TYPE.PUT,
        SERVICE_ENDPOINTS.CustomerReview_Put,
        reqData,
        this.successSaveReview,
      );
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Please fill all mandatory fields',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  render() {
    return getStorageItem(PROFILE_ID) ? (
      <div className="add-product-review">
        <h3 className="text-uppercase heading-text-color font-weight-semibold">
          WRITE YOUR OWN REVIEW
        </h3>
        <p>{'How do you rate this ' + this.props.type.text + '? *'}</p>
        <table className="ratings-table">
          <thead>
            <tr>
              <th>&nbsp;</th>
              <th>1 star</th>
              <th>2 stars</th>
              <th>3 stars</th>
              <th>4 stars</th>
              <th>5 stars</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Rating</td>
              <td>
                <input
                  type="radio"
                  name="ratings"
                  id="Quality_1"
                  defaultValue={1}
                  className="radio"
                  checked={this.state.rating == '1' ? true : false}
                  onChange={(e) => {
                    this.setState({ rating: e.target.value });
                  }}
                />
              </td>
              <td>
                <input
                  type="radio"
                  name="ratings"
                  id="Quality_2"
                  defaultValue={2}
                  className="radio"
                  checked={this.state.rating == '2' ? true : false}
                  onChange={(e) => {
                    this.setState({ rating: e.target.value });
                  }}
                />
              </td>
              <td>
                <input
                  type="radio"
                  name="ratings"
                  id="Quality_3"
                  defaultValue={3}
                  className="radio"
                  checked={this.state.rating == '3' ? true : false}
                  onChange={(e) => {
                    this.setState({ rating: e.target.value });
                  }}
                />
              </td>
              <td>
                <input
                  type="radio"
                  name="ratings"
                  id="Quality_4"
                  defaultValue={4}
                  className="radio"
                  checked={this.state.rating == '4' ? true : false}
                  onChange={(e) => {
                    this.setState({ rating: e.target.value });
                  }}
                />
              </td>
              <td>
                <input
                  type="radio"
                  name="ratings"
                  id="Quality_5"
                  defaultValue={5}
                  className="radio"
                  checked={this.state.rating == '5' ? true : false}
                  onChange={(e) => {
                    this.setState({ rating: e.target.value });
                  }}
                />
              </td>
            </tr>
          </tbody>
        </table>
        <div className="form-group mb-2">
          <label>
            Review <span className="required">*</span>
          </label>
          <textarea
            cols={5}
            rows={6}
            className="form-control form-control-sm"
            defaultValue={''}
            value={this.state.review}
            onChange={(e) => {
              this.setState({ review: e.target.value });
            }}
          />
        </div>
        {/* End .form-group */}
        <button
          className="btn btn-outline-dark custom-btn prebtn"
          onClick={this.handleSubmit}
        >
          Submit Review
        </button>
      </div>
    ) : (
      <div className="add-product-review">
        <h3 className="text-uppercase heading-text-color font-weight-semibold">
          You need to login, in order to write a review for this product
        </h3>
      </div>
    );
  }
}

export default CreateReview;
