package com.ankamagames.dofus.network.messages.game.atlas.compass
{
   import com.ankamagames.dofus.network.types.game.context.MapCoordinates;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CompassUpdatePvpSeekMessage extends CompassUpdateMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6013;
       
      
      private var _isInitialized:Boolean = false;
      
      public var memberId:Number = 0;
      
      public var memberName:String = "";
      
      public function CompassUpdatePvpSeekMessage()
      {
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return super.isInitialized && this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6013;
      }
      
      public function initCompassUpdatePvpSeekMessage(param1:uint = 0, param2:MapCoordinates = null, param3:Number = 0, param4:String = "") : CompassUpdatePvpSeekMessage
      {
         super.initCompassUpdateMessage(param1,param2);
         this.memberId = param3;
         this.memberName = param4;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
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
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_CompassUpdatePvpSeekMessage(param1);
      }
      
      public function serializeAs_CompassUpdatePvpSeekMessage(param1:ICustomDataOutput) : void
      {
         super.serializeAs_CompassUpdateMessage(param1);
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element memberId.");
         }
         param1.writeVarLong(this.memberId);
         param1.writeUTF(this.memberName);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CompassUpdatePvpSeekMessage(param1);
      }
      
      public function deserializeAs_CompassUpdatePvpSeekMessage(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._memberIdFunc(param1);
         this._memberNameFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CompassUpdatePvpSeekMessage(param1);
      }
      
      public function deserializeAsyncAs_CompassUpdatePvpSeekMessage(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._memberIdFunc);
         param1.addChild(this._memberNameFunc);
      }
      
      private function _memberIdFunc(param1:ICustomDataInput) : void
      {
         this.memberId = param1.readVarUhLong();
         if(this.memberId < 0 || this.memberId > 9007199254740990)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element of CompassUpdatePvpSeekMessage.memberId.");
         }
      }
      
      private function _memberNameFunc(param1:ICustomDataInput) : void
      {
         this.memberName = param1.readUTF();
      }
   }
}
