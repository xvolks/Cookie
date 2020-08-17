package com.ankamagames.dofus.network.messages.game.context.roleplay
{
   import com.ankamagames.dofus.network.types.game.interactive.MapObstacle;
   import com.ankamagames.jerakine.network.CustomDataWrapper;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkMessage;
   import com.ankamagames.jerakine.network.NetworkMessage;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   import flash.utils.ByteArray;
   
   [Trusted]
   public class MapObstacleUpdateMessage extends NetworkMessage implements INetworkMessage
   {
      
      public static const protocolId:uint = 6051;
       
      
      private var _isInitialized:Boolean = false;
      
      public var obstacles:Vector.<MapObstacle>;
      
      private var _obstaclestree:FuncTree;
      
      public function MapObstacleUpdateMessage()
      {
         this.obstacles = new Vector.<MapObstacle>();
         super();
      }
      
      override public function get isInitialized() : Boolean
      {
         return this._isInitialized;
      }
      
      override public function getMessageId() : uint
      {
         return 6051;
      }
      
      public function initMapObstacleUpdateMessage(param1:Vector.<MapObstacle> = null) : MapObstacleUpdateMessage
      {
         this.obstacles = param1;
         this._isInitialized = true;
         return this;
      }
      
      override public function reset() : void
      {
         this.obstacles = new Vector.<MapObstacle>();
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
         this.serializeAs_MapObstacleUpdateMessage(param1);
      }
      
      public function serializeAs_MapObstacleUpdateMessage(param1:ICustomDataOutput) : void
      {
         param1.writeShort(this.obstacles.length);
         var _loc2_:uint = 0;
         while(_loc2_ < this.obstacles.length)
         {
            (this.obstacles[_loc2_] as MapObstacle).serializeAs_MapObstacle(param1);
            _loc2_++;
         }
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MapObstacleUpdateMessage(param1);
      }
      
      public function deserializeAs_MapObstacleUpdateMessage(param1:ICustomDataInput) : void
      {
         var _loc4_:MapObstacle = null;
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            _loc4_ = new MapObstacle();
            _loc4_.deserialize(param1);
            this.obstacles.push(_loc4_);
            _loc3_++;
         }
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MapObstacleUpdateMessage(param1);
      }
      
      public function deserializeAsyncAs_MapObstacleUpdateMessage(param1:FuncTree) : void
      {
         this._obstaclestree = param1.addChild(this._obstaclestreeFunc);
      }
      
      private function _obstaclestreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         var _loc3_:uint = 0;
         while(_loc3_ < _loc2_)
         {
            this._obstaclestree.addChild(this._obstaclesFunc);
            _loc3_++;
         }
      }
      
      private function _obstaclesFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:MapObstacle = new MapObstacle();
         _loc2_.deserialize(param1);
         this.obstacles.push(_loc2_);
      }
   }
}
