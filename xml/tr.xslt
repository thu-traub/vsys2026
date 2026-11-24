<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/data">
      <html>
        <body>
            <h1>Demo HTML</h1>
            <div>
                <ul>
                    <xsl:apply-templates select="person"/>
                </ul>
            </div>
        </body>
      </html>
    </xsl:template>

    <xsl:template match="person">
        <li>
            <xsl:value-of select="name"/>
        </li>
    </xsl:template>
</xsl:stylesheet>