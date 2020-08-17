package com.ankamagames.dofus.network.messages.game.pvp
{
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class UpdateMapPlayersAgressableStatusMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6454;
       
      
      private var _isInitialized:Boolean = false;
      
      public var playerIds:Vector.<Number>;
      
      public var enable:Vector.<uint>;
      
      private var _playerIdstree:FuncTree;
      
      private var _enabletree:FuncTree;
      
      public function UpdateMapPlayersAgressableStatusMessage()
      {
         this.playerIds = new Vector.<Number>();
         this.enable = new Vector.<uint>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6454;
      }
      
      public function initUpdateMapPlayersAgressableStatusMessage(param1:Vector.<Number> = null, param2:Vector.<uint> = null) : UpdateMapPlayersAgressableStatusMessage
      {
         this.playerIds = param1;
         this.enable = param2;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.playerIds = new Vector.<Number>();
         this.enable = new Vector.<uint>();
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
         this.serializeAs_UpdateMapPlayersAgressableStatusMessage(param1);
      }
      
      public function serializeAs_UpdateMapPlayersAgressableStatusMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.playerIds.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.playerIds.length)
         {
            if(this.playerIds[_loc2_] < 0 || this.playerIds[_loc2_] > 9007199254740990)
            {
               throw new Error("Forbidden value (" + this.playerIds[_loc2_] + ") on element 1 (starting at 1) of playerIds.");
            }
            param1.writeVarLong(this.playerIds[_loc2_]);
            _loc2_++;
         }
         param1.writeShort(this.enable.length);
         var _loc3_:uint = 0;
         while(_loc3_ < this.enable.length)
         {
            param1.writeByte(this.enable[_loc3_]);
            _loc3_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_UpdateMapPlayersAgressableStatusMessage(param1);
      }
      
      public function deserializeAs_UpdateMapPlayersAgressableStatusMessage(param1:ICustomDataInput) : void
      {
         var _loc6_:Number = NaN;
         var _loc7_:uint = 0;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc6_ = param1.readVarUhLong();
            if(_loc6_ < 0 || _loc6_ > 9007199254740990)
            {
               throw new Error("Forbidden value (" + _loc6_ + ") on elements of playerIds.");
            }
            this.playerIds.push(_loc6_);
            _loc3_++;
         }
         var _loc4_:uint = param1.readUnsignedShort();
         var _loc5_:uint = 0;
         while(_loc5_ < _loc4_)
         {
            _loc7_ = param1.readByte();
            if(_loc7_ < 0)
            {
               throw new Error("Forbidden value (" + _loc7_ + ") on elements of enable.");
            }
            this.enable.push(_loc7_);
            _loc5_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_UpdateMapPlayersAgressableStatusMessage(param1);
      }
      
      public function deserializeAsyncAs_UpdateMapPlayersAgressableStatusMessage(param1:FuncTree) : void
      {
         this._playerIdstree = param1.addChild(this._playerIdstreeFunc);
         this._enabletree = param1.addChild(this._enabletreeFunc);
      }
      
      private function _playerIdstreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._playerIdstree.addChild(this._playerIdsFunc);
            _loc3_++;
         }
      }
      
      private function _playerIdsFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:Number = param1.readVarUhLong();
         if(_loc2_ < 0 || _loc2_ > 9007199254740990)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of playerIds.");
         }
         this.playerIds.push(_loc2_);
      }
      
      private function _enabletreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._enabletree.addChild(this._enableFunc);
            _loc3_++;
         }
      }
      
      private function _enableFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readByte();
         if(_loc2_ < 0)
         {
            throw new Error("Forbidden value (" + _loc2_ + ") on elements of enable.");
         }
         this.enable.push(_loc2_);
      }
   }
}
