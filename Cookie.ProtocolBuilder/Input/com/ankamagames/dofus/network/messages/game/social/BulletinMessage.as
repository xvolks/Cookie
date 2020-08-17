package com.ankamagames.dofus.network.messages.game.social
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class BulletinMessage extends SocialNoticeMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6695;
       
      
      private var _isInitialized:Boolean = false;
      
      public var lastNotifiedTimestamp:uint = 0;
      
      public function BulletinMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6695;
      }
      
      public function initBulletinMessage(param1:String = "", param2:uint = 0, param3:Number = 0, param4:String = "", param5:uint = 0) : BulletinMessage
      {
         super.initSocialNoticeMessage(param1,param2,param3,param4);
         this.lastNotifiedTimestamp = param5;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.lastNotifiedTimestamp = 0;
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_BulletinMessage(param1);
      }
      
      public function serializeAs_BulletinMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_SocialNoticeMessage(param1);
         if(this.lastNotifiedTimestamp < 0)
         {
            throw new Error("Forbidden value (" + this.lastNotifiedTimestamp + ") on element lastNotifiedTimestamp.");
         }
         param1.writeInt(this.lastNotifiedTimestamp);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_BulletinMessage(param1);
      }
      
      public function deserializeAs_BulletinMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._lastNotifiedTimestampFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_BulletinMessage(param1);
      }
      
      public function deserializeAsyncAs_BulletinMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._lastNotifiedTimestampFunc);
      }
      
      private function _lastNotifiedTimestampFunc(param1:ICustomDataInput) : void
      {
         this.lastNotifiedTimestamp = param1.readInt();
         if(this.lastNotifiedTimestamp < 0)
         {
            throw new Error("Forbidden value (" + this.lastNotifiedTimestamp + ") on element of BulletinMessage.lastNotifiedTimestamp.");
         }
      }
   }
}
