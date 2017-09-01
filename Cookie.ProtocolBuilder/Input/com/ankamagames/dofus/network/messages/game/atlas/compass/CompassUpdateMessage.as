package com.ankamagames.dofus.network.messages.game.atlas.compass
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.dofus.network.types.game.context.MapCoordinates;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class CompassUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 5591;
       
      
      private var _isInitialized:Boolean = false;
      
      public var type:uint = 0;
      
      public var coords:MapCoordinates;
      
      private var _coordstree:FuncTree;
      
      public function CompassUpdateMessage()
      {
         this.coords = new MapCoordinates();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 5591;
      }
      
      public function initCompassUpdateMessage(param1:uint = 0, param2:MapCoordinates = null) : CompassUpdateMessage
      {
         this.type = param1;
         this.coords = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.type = 0;
         this.coords = new MapCoordinates();
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
         this.serializeAs_CompassUpdateMessage(param1);
      }
      
      public function serializeAs_CompassUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeByte(this.type);
         param1.writeShort(this.coords.getTypeId());
         this.coords.serialize(param1);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_CompassUpdateMessage(param1);
      }
      
      public function deserializeAs_CompassUpdateMessage(param1:ICustomDataInput) : void
      {
         this._typeFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.coords = ProtocolTypeManager.getInstance(MapCoordinates,_loc2_);
         this.coords.deserialize(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_CompassUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_CompassUpdateMessage(param1:FuncTree) : void
      {
         param1.addChild(this._typeFunc);
         this._coordstree = param1.addChild(this._coordstreeFunc);
      }
      
      private function _typeFunc(param1:ICustomDataInput) : void
      {
         this.type = param1.readByte();
         if(this.type < 0)
         {
            throw new Error("Forbidden value (" + this.type + ") on element of CompassUpdateMessage.type.");
         }
      }
      
      private function _coordstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.coords = ProtocolTypeManager.getInstance(MapCoordinates,_loc2_);
         this.coords.deserializeAsync(this._coordstree);
      }
   }
}
