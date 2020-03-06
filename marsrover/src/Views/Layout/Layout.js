import React, { Component } from "react";
import { Layout } from "antd"; 
import  HeaderPage  from "./Header";
import  ContentPage  from "./Content";
import  FooterPage  from "./Footer";

class LayoutDiv extends Component {
  render() {
    return (
      <div>
        <Layout className="layout">
          <HeaderPage></HeaderPage>
          <ContentPage></ContentPage>
          <FooterPage FooterText={"Osman Yalçınkaya"}></FooterPage>
        </Layout>
      </div>
    );
  }
}

export default LayoutDiv;
