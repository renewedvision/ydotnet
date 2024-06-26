import * as React from 'react';
import * as Y from 'yjs';
import { WebsocketProvider } from 'y-websocket';
import config from '../config';

export interface IYjsContext {
    readonly yjsDocument: Y.Doc;
    readonly yjsConnector: WebsocketProvider;
    readonly roomName: string;
}

export interface IOptions extends React.PropsWithChildren<object> {
    readonly roomName: string;
}

export const YjsContextProvider: React.FunctionComponent<IOptions> = (
    props: IOptions
) => {
    const { roomName } = props;
    const baseUrl = `${config.WS_URL}/collaboration`;

    const contextProps: IYjsContext = React.useMemo(() => {
        const yjsDocument = new Y.Doc();
        const yjsConnector = new WebsocketProvider(
            baseUrl,
            roomName,
            yjsDocument
        );

        return { yjsDocument, yjsConnector, roomName };
    }, [baseUrl, roomName]);

    return (
        <YjsContext.Provider value={contextProps}>
            {props.children}
        </YjsContext.Provider>
    );
};

export const YjsContext = React.createContext<IYjsContext | undefined>(
    undefined
);
