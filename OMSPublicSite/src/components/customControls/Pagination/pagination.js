import React from 'react';

class Pagination extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    let numberOfPages = Math.ceil(
      this.props.totalRecords / this.props.DISPLAY_PAGES,
    );
    let pageObj = {
      pageArr: [],
      showLastPage: false,
      isPrevEnabled: false,
      isNextEnabled: false,
    };

    let startIdx =
      this.props.currPage - this.props.DISPLAY_PAGES < 0
        ? 1
        : this.props.currPage < numberOfPages
        ? this.props.currPage - (this.props.DISPLAY_PAGES - 2)
        : this.props.currPage - (this.props.DISPLAY_PAGES - 1);
    let endIdx =
      startIdx + this.props.DISPLAY_PAGES - 1 > numberOfPages
        ? numberOfPages
        : startIdx + this.props.DISPLAY_PAGES - 1;

    for (let i = startIdx; i <= endIdx; i++) {
      if (i == this.props.currPage) {
        pageObj.pageArr.push(
          <li className="page-item active" key={i}>
            <a
              className="page-link"
              href="#"
              onClick={(e) => {
                e.preventDefault();
                this.props.setCurrentPage(i);
              }}
            >
              {i}
              <span className="sr-only">(current)</span>
            </a>
          </li>,
        );
      } else {
        pageObj.pageArr.push(
          <li className="page-item" key={i}>
            <a
              className="page-link"
              href="#"
              onClick={(e) => {
                e.preventDefault();
                this.props.setCurrentPage(i);
              }}
            >
              {i}
              <span className="sr-only">(current)</span>
            </a>
          </li>,
        );
      }
    }

    pageObj.isPrevEnabled = startIdx == 1 ? false : true;
    pageObj.isNextEnabled = endIdx == numberOfPages ? false : true;
    pageObj.showLastPage = endIdx == numberOfPages ? false : true;
    return (
      <nav class="toolbox toolbox-pagination">
        <ul className="pagination">
          {!pageObj.isPrevEnabled ? (
            <li className="page-item disabled">
              <a className="page-link page-link-btn" href="#">
                <i className="icon-angle-left" />
              </a>
            </li>
          ) : (
            <li className="page-item">
              <a
                className="page-link page-link-btn"
                href="#"
                onClick={(e) => {
                  e.preventDefault();
                  this.props.setCurrentPage(this.props.currPage - 1);
                }}
              >
                <i className="icon-angle-left" />
              </a>
            </li>
          )}
          {pageObj.pageArr}
          {pageObj.showLastPage ? (
            <>
              <li className="page-item">
                <span>...</span>
              </li>
              <li className="page-item">
                <a
                  className="page-link"
                  href="#"
                  onClick={(e) => {
                    e.preventDefault();
                    this.props.setCurrentPage(numberOfPages);
                  }}
                >
                  {numberOfPages}
                  <span className="sr-only">(current)</span>
                </a>
              </li>
            </>
          ) : (
            <></>
          )}
          {!pageObj.isNextEnabled ? (
            <li className="page-item disabled">
              <a className="page-link page-link-btn" href="#">
                <i className="icon-angle-right"></i>
              </a>
            </li>
          ) : (
            <li className="page-item ">
              <a
                className="page-link page-link-btn"
                href="#"
                onClick={(e) => {
                  e.preventDefault();
                  this.props.setCurrentPage(this.props.currPage + 1);
                }}
              >
                <i className="icon-angle-right"></i>
              </a>
            </li>
          )}
        </ul>
      </nav>
    );
  }
}
export default Pagination;
