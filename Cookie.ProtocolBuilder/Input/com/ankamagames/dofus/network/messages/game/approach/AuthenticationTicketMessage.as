package com.ankamagames.dofus.network.messages.game.approach
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class AuthenticationTicketMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 110;
       
      
      private var _isInitialized:Boolean = false;
      
      public var lang:String = "";
      
      public var ticket:String = "";
      
      public function AuthenticationTicketMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 110;
      }
      
      public function initAuthenticationTicketMessage(param1:String = "", param2:String = "") : AuthenticationTicketMessage
      {
         this.lang = param1;
         this.ticket = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.lang = "";
         this.ticket = "";
         this._isInitialized = false;
      }
      
      override public function pack(param1:ICustomDataOutput) : void
      {
         var _loc2_:ByteArray = new ByteArray();
         this.serialize(new CustomDataWrapper(_loc2_));
         writePacket(param1,this.getMessageId(),_loc2_);
      }
      
      override public function unpack(param1:ICustomDataInput, param2:uint) : void
      {
         this.deserialize(param1);
      }
      
      override public function unpackAsync(param1:ICustomDataInput, param2:uint) : FuncTree
      {
         var _loc3_:FuncTree = new FuncTree();
         _loc3_.setRoot(param1);
         this.deserializeAsync(_loc3_);
         return _loc3_;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_AuthenticationTicketMessage(param1);
      }
      
      public function serializeAs_AuthenticationTicketMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.lang);
         param1.writeUTF(this.ticket);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_AuthenticationTicketMessage(param1);
      }
      
      public function deserializeAs_AuthenticationTicketMessage(param1:ICustomDataInput) : void
      {
         this._langFunc(param1);
         this._ticketFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_AuthenticationTicketMessage(param1);
      }
      
      public function deserializeAsyncAs_AuthenticationTicketMessage(param1:FuncTree) : void
      {
         param1.addChild(this._langFunc);
         param1.addChild(this._ticketFunc);
      }
      
      private function _langFunc(param1:ICustomDataInput) : void
      {
         this.lang = param1.readUTF();
      }
      
      private function _ticketFunc(param1:ICustomDataInput) : void
      {
         this.ticket = param1.readUTF();
      }
   }
}
