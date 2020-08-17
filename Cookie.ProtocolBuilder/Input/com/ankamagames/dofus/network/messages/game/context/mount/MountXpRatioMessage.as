package com.ankamagames.dofus.network.messages.game.context.mount
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MountXpRatioMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5970;
       
      
      private var _isInitialized:Boolean = false;
      
      public var ratio:uint = 0;
      
      public function MountXpRatioMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5970;
      }
      
      public function initMountXpRatioMessage(param1:uint = 0) : MountXpRatioMessage
      {
         this.ratio = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.ratio = 0;
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
         this.serializeAs_MountXpRatioMessage(param1);
      }
      
      public function serializeAs_MountXpRatioMessage(param1:ICustomDataOutput) : void
      {
         if(this.ratio < 0)
         {
            throw new Error("Forbidden value (" + this.ratio + ") on element ratio.");
         }
         param1.writeByte(this.ratio);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MountXpRatioMessage(param1);
      }
      
      public function deserializeAs_MountXpRatioMessage(param1:ICustomDataInput) : void
      {
         this._ratioFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MountXpRatioMessage(param1);
      }
      
      public function deserializeAsyncAs_MountXpRatioMessage(param1:FuncTree) : void
      {
         param1.addChild(this._ratioFunc);
      }
      
      private function _ratioFunc(param1:ICustomDataInput) : void
      {
         this.ratio = param1.readByte();
         if(this.ratio < 0)
         {
            throw new Error("Forbidden value (" + this.ratio + ") on element of MountXpRatioMessage.ratio.");
         }
      }
   }
}
