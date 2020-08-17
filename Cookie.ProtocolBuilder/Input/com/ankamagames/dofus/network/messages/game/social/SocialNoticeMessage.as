package com.ankamagames.dofus.network.messages.game.social
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class SocialNoticeMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6688;
       
      
      private var _isInitialized:Boolean = false;
      
      [Transient]
      public var content:String = "";
      
      public var timestamp:uint = 0;
      
      public var memberId:Number = 0;
      
      public var memberName:String = "";
      
      public function SocialNoticeMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6688;
      }
      
      public function initSocialNoticeMessage(param1:String = "", param2:uint = 0, param3:Number = 0, param4:String = "") : SocialNoticeMessage
      {
         this.content = param1;
         this.timestamp = param2;
         this.memberId = param3;
         this.memberName = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.content = "";
         this.timestamp = 0;
         this.memberId = 0;
         this.memberName = "";
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
         this.serializeAs_SocialNoticeMessage(param1);
      }
      
      public function serializeAs_SocialNoticeMessage(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.content);
         if(this.timestamp < 0)
         {
            throw new Error("Forbidden value (" + this.timestamp + ") on element timestamp.");
         }
         param1.writeInt(this.timestamp);
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element memberId.");
         }
         param1.writeVarLong(this.memberId);
         param1.writeUTF(this.memberName);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_SocialNoticeMessage(param1);
      }
      
      public function deserializeAs_SocialNoticeMessage(param1:ICustomDataInput) : void
      {
         this._contentFunc(param1);
         this._timestampFunc(param1);
         this._memberIdFunc(param1);
         this._memberNameFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_SocialNoticeMessage(param1);
      }
      
      public function deserializeAsyncAs_SocialNoticeMessage(param1:FuncTree) : void
      {
         param1.addChild(this._contentFunc);
         param1.addChild(this._timestampFunc);
         param1.addChild(this._memberIdFunc);
         param1.addChild(this._memberNameFunc);
      }
      
      private function _contentFunc(param1:ICustomDataInput) : void
      {
         this.content = param1.readUTF();
      }
      
      private function _timestampFunc(param1:ICustomDataInput) : void
      {
         this.timestamp = param1.readInt();
         if(this.timestamp < 0)
         {
            throw new Error("Forbidden value (" + this.timestamp + ") on element of SocialNoticeMessage.timestamp.");
         }
      }
      
      private function _memberIdFunc(param1:ICustomDataInput) : void
      {
         this.memberId = param1.readVarUhLong();
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element of SocialNoticeMessage.memberId.");
         }
      }
      
      private function _memberNameFunc(param1:ICustomDataInput) : void
      {
         this.memberName = param1.readUTF();
      }
   }
}
