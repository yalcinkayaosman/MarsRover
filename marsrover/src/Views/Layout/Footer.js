import React, { Component } from "react";
import { Layout } from "antd";
const { Footer } = Layout;

class FooterDiv extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Footer style={{ textAlign: "center" }}>{this.props.FooterText}</Footer>
    );
  }
}
export default FooterDiv;
